using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class GenericDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> dict = new();

        public void Add(TKey key, TValue value)
        {
            if (!dict.ContainsKey(key))
            {
                dict[key] = value;
                Console.WriteLine($"Added: [{key}] = {value}");
            }
            else
            {
                Console.WriteLine($"Key already exists: {key}");
            }
        }

        public void Remove(TKey key)
        {
            if (dict.Remove(key))
                Console.WriteLine($"Removed: {key}");
            else
                Console.WriteLine($"Key not found: {key}");
        }

        public void Search(TKey key)
        {
            if (dict.TryGetValue(key, out var value))
                Console.WriteLine($" Found: [{key}] = {value}");
            else
                Console.WriteLine($"Key not found: {key}");
        }

        public void Display()
        {
            Console.WriteLine("DICTIONARY Contents:");
            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }
        }
    }

}
