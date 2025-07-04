namespace Collections
{
    public class GenericDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _dictionary;
        public GenericDictionary()
        {
            _dictionary = new();
        }

        /// <summary>
        /// Adds a key value pair to a generic dictionary.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void Add(TKey key, TValue value)
        {
            if (!_dictionary.ContainsKey(key))
            {
                _dictionary[key] = value;
                Console.WriteLine($"Added: [{key}] = {value}");
            }
            else
            {
                Console.WriteLine($"Key already exists: {key}");
            }
        }

        /// <summary>
        /// Removes an entry from the generic dictionary.
        /// </summary>
        /// <param name="key">Key of the pair to be removed</param>
        public void Remove(TKey key)
        {
            if (_dictionary.Remove(key))
            {
                Console.WriteLine($"Removed: {key}");
            }
            else
            {
                Console.WriteLine($"Key not found: {key}");
            }
        }

        /// <summary>
        /// Searches for a key in the generic dictionary.
        /// </summary>
        /// <param name="key">Key of the pair to be searched</param>
        public void Search(TKey key)
        {
            if (_dictionary.TryGetValue(key, out var value))
            {
                Console.WriteLine($" Found: [{key}] = {value}");
            }
            else
            {
                Console.WriteLine($"Key not found: {key}");
            }
        }

        /// <summary>
        /// Displays all the key value pairs in the generic dictionary.
        /// </summary>
        public void Display()
        {
            Console.WriteLine("DICTIONARY Contents:");
            foreach (var pair in _dictionary)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }
        }
    }
}
