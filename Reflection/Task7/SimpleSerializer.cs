using System.Reflection;
using System.Text.Json;
using System.Collections;

namespace Task7
{
    public class SimpleSerializer
    {
        public string Serialize(object obj)
        {
            if (obj == null) return "null";

            Type type = obj.GetType();
            if (type.IsPrimitive || obj is string)
            {
                return JsonSerializer.Serialize(obj);
            }

            if (obj is IEnumerable enumerable)
            {
                var list = new List<string>();
                foreach (var item in enumerable)
                {
                    list.Add(Serialize(item));
                }
                return "[" + string.Join(",", list) + "]";
            }

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var dictionary = new Dictionary<string, string>();

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                dictionary[property.Name] = Serialize(value);
            }

            return JsonSerializer.Serialize(dictionary);
        }
    }

}
