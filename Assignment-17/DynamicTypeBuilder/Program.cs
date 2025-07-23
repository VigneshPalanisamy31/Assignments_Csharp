using System.Reflection;
using System.Reflection.Emit;
namespace DynamicTypeBuilder
{
    internal class Program
    {
        public static void Main()
        {
            try
            {
                AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
                AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(
                    assemblyName, AssemblyBuilderAccess.Run);
                ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
                TypeBuilder typeBuilder = moduleBuilder.DefineType("Person",
                    TypeAttributes.Public);

                FieldBuilder fieldBuilder = typeBuilder.DefineField("name", typeof(string), FieldAttributes.Private);
                PropertyBuilder propertyBuilder = typeBuilder.DefineProperty("Name", PropertyAttributes.HasDefault, typeof(string), null);
                MethodBuilder getMethodBuilder = typeBuilder.DefineMethod("get_Name",
                    MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                    typeof(string), Type.EmptyTypes);

                ILGenerator getIL = getMethodBuilder.GetILGenerator();
                getIL.Emit(OpCodes.Ldarg_0);
                getIL.Emit(OpCodes.Ldfld, fieldBuilder);
                getIL.Emit(OpCodes.Ret);

                MethodBuilder setMethodBuilder = typeBuilder.DefineMethod("set_Name",
                    MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                    null, new Type[] { typeof(string) });

                ILGenerator setIL = setMethodBuilder.GetILGenerator();
                setIL.Emit(OpCodes.Ldarg_0);
                setIL.Emit(OpCodes.Ldarg_1);
                setIL.Emit(OpCodes.Stfld, fieldBuilder);
                setIL.Emit(OpCodes.Ret);

                propertyBuilder.SetGetMethod(getMethodBuilder);
                propertyBuilder.SetSetMethod(setMethodBuilder);

                MethodBuilder sayHelloBuilder = typeBuilder.DefineMethod("SayHello",
                    MethodAttributes.Public, typeof(void), Type.EmptyTypes);

                ILGenerator helloIL = sayHelloBuilder.GetILGenerator();
                helloIL.Emit(OpCodes.Ldstr, "Hello, my name is ");
                helloIL.Emit(OpCodes.Ldarg_0);
                helloIL.Emit(OpCodes.Call, getMethodBuilder);
                MethodInfo concatMethod = typeof(string).GetMethod("Concat", new Type[] { typeof(string), typeof(string) });
                helloIL.Emit(OpCodes.Call, concatMethod);
                MethodInfo writeLineMethod = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) });
                helloIL.Emit(OpCodes.Call, writeLineMethod);
                helloIL.Emit(OpCodes.Ret);
                Type personType = typeBuilder.CreateType();
                object personInstance = Activator.CreateInstance(personType);
                PropertyInfo nameProp = personType.GetProperty("Name");
                nameProp.SetValue(personInstance, "Vicky", null);
                MethodInfo sayHelloMethod = personType.GetMethod("SayHello");
                sayHelloMethod.Invoke(personInstance, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}

