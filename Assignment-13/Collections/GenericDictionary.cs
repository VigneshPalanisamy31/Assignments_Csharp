namespace Collections
{
    public class GenericDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> dict = new();

        /// <summary>
        /// Function to add a key value pair to a generic dictionary.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void Add(TKey key, TValue value)
        {
            if (!dict.ContainsKey(key))
            {
                dict[key] = value;
                Console.WriteLine($"Added: [{key}] = {value}");
            }
            else
                Console.WriteLine($"Key already exists: {key}");
        }

        /// <summary>
        /// Function to remove an entry from the generic dictionary.
        /// </summary>
        /// <param name="key">Key</param>
        public void Remove(TKey key)
        {
            if (dict.Remove(key))
                Console.WriteLine($"Removed: {key}");
            else
                Console.WriteLine($"Key not found: {key}");
        }

        /// <summary>
        /// Function to search for a key in the generic dictionary.
        /// </summary>
        /// <param name="key">Key</param>
        public void Search(TKey key)
        {
            if (dict.TryGetValue(key, out var value))
                Console.WriteLine($" Found: [{key}] = {value}");
            else
                Console.WriteLine($"Key not found: {key}");
        }

        /// <summary>
        /// Function to display all the key value pairs in the generic dictionary.
        /// </summary>
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
