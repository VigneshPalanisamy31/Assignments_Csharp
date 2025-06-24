using System.Reflection;
using System.Reflection.Emit;
namespace DynamicMocker
{
    internal class MockBuilder
    {
        /// <summary>
        /// Dynamically mocks an interface
        /// </summary>
        /// <param name="interfaceType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static object CreateMock(Type interfaceType)
        {
            if (!interfaceType.IsInterface)
                throw new ArgumentException("Only interfaces can be mocked.");
            AssemblyName assemblyName = new AssemblyName("DynamicMocksAssembly");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
            string typeName = $"Mock_{interfaceType.Name}";
            TypeBuilder typeBuilder = moduleBuilder.DefineType(typeName,
                TypeAttributes.Public | TypeAttributes.Class, null, new[] { interfaceType });
            foreach (MethodInfo method in interfaceType.GetMethods())
            {
                if (method.IsSpecialName) continue;
                Type[] paramTypes = Array.ConvertAll(method.GetParameters(), p => p.ParameterType);
                MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                    method.Name,
                    MethodAttributes.Public | MethodAttributes.Virtual,
                    method.ReturnType,
                    paramTypes
                );
                ILGenerator il = methodBuilder.GetILGenerator();
                if (method.ReturnType == typeof(void))
                    il.Emit(OpCodes.Ret);
                else if (method.ReturnType.IsValueType)
                {
                    LocalBuilder local = il.DeclareLocal(method.ReturnType);
                    il.Emit(OpCodes.Ldloca_S, local);
                    il.Emit(OpCodes.Initobj, method.ReturnType);
                    il.Emit(OpCodes.Ldloc_0);
                    il.Emit(OpCodes.Ret);
                }
                else
                {
                    il.Emit(OpCodes.Ldnull);
                    il.Emit(OpCodes.Ret);
                }
                typeBuilder.DefineMethodOverride(methodBuilder, method);
            }
            foreach (PropertyInfo prop in interfaceType.GetProperties())
            {
                FieldBuilder field = typeBuilder.DefineField($"_{prop.Name.ToLower()}", prop.PropertyType, FieldAttributes.Private);
                PropertyBuilder propBuilder = typeBuilder.DefineProperty(prop.Name, PropertyAttributes.None, prop.PropertyType, null);
                if (prop.GetGetMethod() != null)
                {
                    MethodBuilder getMethod = typeBuilder.DefineMethod($"get_{prop.Name}",
                        MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                        prop.PropertyType, Type.EmptyTypes);
                    ILGenerator il = getMethod.GetILGenerator();
                    if (prop.PropertyType.IsValueType)
                    {
                        LocalBuilder local = il.DeclareLocal(prop.PropertyType);
                        il.Emit(OpCodes.Ldloca_S, local);
                        il.Emit(OpCodes.Initobj, prop.PropertyType);
                        il.Emit(OpCodes.Ldloc_0);
                    }
                    else
                        il.Emit(OpCodes.Ldnull);
                    il.Emit(OpCodes.Ret);
                    typeBuilder.DefineMethodOverride(getMethod, prop.GetGetMethod());
                    propBuilder.SetGetMethod(getMethod);
                }
            }
            Type mockType = typeBuilder.CreateType();
            return Activator.CreateInstance(mockType);
        }
    }
}
