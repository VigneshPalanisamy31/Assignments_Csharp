namespace Collections
{
    public class GenericCollection<T>
    {
        private List<T> _list;
        private Queue<T> _queue;
        private Stack<T> _stack;
        private string _activeType;

        public GenericCollection(string collectionType)
        {
            switch (collectionType.ToLower())
            {
                case "list":
                    _list = new List<T>();
                    _activeType = "list";
                    break;

                case "queue":
                    _queue = new Queue<T>();
                    _activeType = "queue";
                    break;

                case "stack":
                    _stack = new Stack<T>();
                    _activeType = "stack";
                    break;

                default:
                    Console.WriteLine("Invalid collection type. Choose 'list', 'queue', or 'stack'.");
                    break;
            }
        }

        /// <summary>
        /// Adds items to the generic collections.
        /// </summary>
        /// <param name="item">Item to add to the collection</param>
        public void Add(T item)
        {
            switch (_activeType)
            {
                case "list":
                    _list.Add(item);
                    Console.WriteLine($"Added to List: {item}");
                    break;

                case "queue":
                    _queue.Enqueue(item);
                    Console.WriteLine($"Enqueued to Queue: {item}");
                    break;

                case "stack":
                    _stack.Push(item);
                    Console.WriteLine($"Pushed to Stack: {item}");
                    break;
            }
        }

        /// <summary>
        /// Displays the elements of the generic collections.
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"\nActive collection: {_activeType.ToUpper()}");
            switch (_activeType)
            {
                case "list":
                    foreach (var item in _list)
                    {
                        Console.WriteLine(item);
                    }

                    break;

                case "queue":
                    foreach (var item in _queue)
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case "stack":
                    foreach (var item in _stack)
                    {
                        Console.Write(item);
                    }
                    break;
            }
        }

        /// <summary>
        /// Removes elements from the generic collections.
        /// </summary>
        public void Remove()
        {
            switch (_activeType)
            {
                case "list":
                    while (_list.Any())
                    {
                        Console.WriteLine($"Removed from list: {_list[0]}");
                        _list.RemoveAt(0);
                    }
                    break;

                case "queue":
                    while (_queue.Any())
                    {
                        Console.WriteLine($"Removed from queue: {_queue.Dequeue()}");
                    }
                    break;

                case "stack":
                    while (_stack.Any())
                    {
                        Console.WriteLine($"Removed from stack: {_stack.Pop()}");
                    }
                    break;
            }
        }
    }
}
