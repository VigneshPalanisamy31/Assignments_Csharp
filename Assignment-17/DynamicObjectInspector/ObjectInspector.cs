using System.Reflection;
namespace DynamicObjectInspector
{
    public class ObjectInspector
    {
        /// <summary>
        /// Displays properties and their current values
        /// </summary>
        /// <param name="obj"></param>
        public static void Inspect(object obj)
        {
            Type type = obj.GetType();
            Console.WriteLine($"Inspecting object of type: {type.Name}");
            PropertyInfo[] properties = type.GetProperties();
            foreach (var prop in properties)
            {
                object value = prop.GetValue(obj);
                Console.WriteLine($"{prop.Name} = {value}");
            }
        }
        /// <summary>
        /// Sets a property value dynamically by name
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="newValue"></param>
        public static void SetProperty(object obj, string propertyName, string newValue)
        {
            Type type = obj.GetType();
            PropertyInfo? prop = type.GetProperty(propertyName);
            if (prop == null || !prop.CanWrite)
            {
                Console.WriteLine($"Property '{propertyName}' not found or not writable.");
                return;
            }
            // Convert the string input to the property's type
            object? convertedValue = Convert.ChangeType(newValue, prop.PropertyType);
            prop.SetValue(obj, convertedValue);
            Console.WriteLine($"Property '{propertyName}' updated to: {convertedValue}");
        }
    }
}
