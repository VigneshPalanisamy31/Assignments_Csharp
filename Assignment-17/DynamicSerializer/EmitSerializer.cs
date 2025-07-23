using System.Reflection;
using System.Reflection.Emit;
using System.Text;
namespace DynamicSerializer
{
    internal class EmitSerializer
    {
        /// <summary>
        /// Dynamically creates a serializer for the given type .
        /// </summary>
        /// <typeparam name="T">Type for which serializer is created</typeparam>
        /// <returns>A delegate</returns>
        public static Func<T,string>CreateSerializer<T>()
        {
            Type type = typeof(T);
            DynamicMethod method=new DynamicMethod($"Serialize_{type}", typeof(string), new[] {type});
            ILGenerator ilGenerator=method.GetILGenerator();
            ConstructorInfo sbConstructor=typeof(StringBuilder).GetConstructor(Type.EmptyTypes);
            MethodInfo sbAppendLine = typeof(StringBuilder).GetMethod("AppendLine", new[] {typeof(string)});
            MethodInfo sbToString = typeof(StringBuilder).GetMethod("ToString",Type.EmptyTypes);
            LocalBuilder sbLocal=ilGenerator.DeclareLocal(typeof(StringBuilder));
            ilGenerator.Emit(OpCodes.Newobj, sbConstructor);
            ilGenerator.Emit(OpCodes.Stloc, sbLocal);
            ilGenerator.Emit(OpCodes.Ldloc, sbLocal);
            ilGenerator.Emit(OpCodes.Ldstr, $"Type: {type}");
            ilGenerator.Emit(OpCodes.Callvirt,sbAppendLine);
            ilGenerator.Emit(OpCodes.Pop);
            foreach(PropertyInfo propertyInfo in type.GetProperties(BindingFlags.Public|BindingFlags.Instance))
            {
                MethodInfo getter=propertyInfo.GetGetMethod();
                if (getter == null) continue;
                ilGenerator.Emit(OpCodes.Ldloc,sbLocal);
                ilGenerator.Emit(OpCodes.Ldstr, $"{propertyInfo.Name} = ");
                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.Emit(OpCodes.Callvirt, getter);

                if (propertyInfo.PropertyType.IsValueType)
                    ilGenerator.Emit(OpCodes.Box,propertyInfo.PropertyType);
                ilGenerator.Emit(OpCodes.Call, typeof(Convert).GetMethod("ToString",new[]{typeof(object)}));
                ilGenerator.Emit(OpCodes.Call,typeof(string).GetMethod("Concat",new[] {typeof(string),typeof(string)}));
                ilGenerator.Emit(OpCodes.Callvirt, sbAppendLine);
                ilGenerator.Emit(OpCodes.Pop);
                }
            ilGenerator.Emit(OpCodes.Ldloc, sbLocal);
            ilGenerator.Emit(OpCodes.Callvirt, sbToString);
            ilGenerator.Emit(OpCodes.Ret);
        return (Func<T,string>)method.CreateDelegate(typeof(Func<T,string>));
        }
    }
}
