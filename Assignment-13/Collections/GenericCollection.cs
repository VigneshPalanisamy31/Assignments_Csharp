namespace Collections
{
    public class GenericCollection<T>
    {
        private List<T> _list;
        private Queue<T> _queue;
        private Stack<T> _stack;
        private CollectionType _activeType;

        public GenericCollection(CollectionType collectionType)
        {
            _activeType = collectionType;
            switch (collectionType)
            {
                case CollectionType.List:
                    _list = new List<T>();
                    break;

                case CollectionType.Queue:
                    _queue = new Queue<T>();
                    break;

                case CollectionType.Stack:
                    _stack = new Stack<T>();
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
                case CollectionType.List:
                    _list.Add(item);
                    Console.WriteLine($"Added to List: {item}");
                    break;

                case CollectionType.Queue:
                    _queue.Enqueue(item);
                    Console.WriteLine($"Enqueued to Queue: {item}");
                    break;

                case CollectionType.Stack:
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
            Console.WriteLine($"\nActive collection: {_activeType}");
            switch (_activeType)
            {
                case CollectionType.List:
                    foreach (var item in _list)
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case CollectionType.Queue:
                    foreach (var item in _queue)
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case CollectionType.Stack:
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
        public void RemoveAll()
        {
            switch (_activeType)
            {
                case CollectionType.List:
                    while (_list.Any())
                    {
                        Console.WriteLine($"Removed from list: {_list[0]}");
                        _list.RemoveAt(0);
                    }
                    break;

                case CollectionType.Queue:
                    while (_queue.Any())
                    {
                        Console.WriteLine($"Removed from queue: {_queue.Dequeue()}");
                    }
                    break;

                case CollectionType.Stack:
                    while (_stack.Any())
                    {
                        Console.WriteLine($"Removed from stack: {_stack.Pop()}");
                    }
                    break;
            }
        }
    }
}
