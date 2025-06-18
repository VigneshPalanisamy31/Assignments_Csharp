using System.Reflection;
using System.Text;
namespace DynamicSerializer
{
    internal class Serializer
    {
        public static string Serialize(object obj)
        {
            if (obj == null)
                return null;
            Type objType= obj.GetType();
            PropertyInfo[] properties = objType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type: {obj.GetType()}");
            foreach (PropertyInfo property in properties)
            {
                var value= property.GetValue(obj, null);
                sb.AppendLine($"{property.Name} = {value}");
            }
          return sb.ToString();
        }
    }
}
