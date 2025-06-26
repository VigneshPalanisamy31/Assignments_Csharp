namespace Collections
{
    public class GenericCollection<T>
    {
        private List<T> list;
        private Queue<T> queue;
        private Stack<T> stack;
        private string activeType;
        public GenericCollection(string collectionType)
        {
            switch (collectionType.ToLower())
            {
                case "list":
                    list = new List<T>();
                    activeType = "list";
                    break;
                case "queue":
                    queue = new Queue<T>();
                    activeType = "queue";
                    break;
                case "stack":
                    stack = new Stack<T>();
                    activeType = "stack";
                    break;
                default:
                    throw new ArgumentException("Invalid collection type. Choose 'list', 'queue', or 'stack'.");
            }
        }

        /// <summary>
        /// Function to add items to the generic collections.
        /// </summary>
        /// <param name="item">Item to add to the collection</param>
        public void Add(T item)
        {
            switch (activeType)
            {
                case "list":
                    list.Add(item);
                    Console.WriteLine($"Added to List: {item}");
                    break;
                case "queue":
                    queue.Enqueue(item);
                    Console.WriteLine($"Enqueued to Queue: {item}");
                    break;
                case "stack":
                    stack.Push(item);
                    Console.WriteLine($"Pushed to Stack: {item}");
                    break;
            }
        }

        /// <summary>
        /// Function to display the elements of the generic collections.
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"\nActive collection: {activeType.ToUpper()}");
            switch (activeType)
            {
                case "list":
                    foreach (var item in list) Console.WriteLine(item);
                    break;
                case "queue":
                    foreach (var item in queue) Console.WriteLine(item);
                    break;
                case "stack":
                    foreach (var item in stack) Console.Write(item);
                    break;
            }
        }

        /// <summary>
        /// Function to remove elements from the generic collections.
        /// </summary>
        public void Remove()
        {
            switch (activeType)
            {
                case "list":
                    while (list.Count > 0)
                    {
                        Console.WriteLine($"Removed from list: {list[0]}");
                        list.RemoveAt(0);
                    }
                    break;
                case "queue":
                    while (queue.Count > 0)
                    {
                        Console.WriteLine($"Removed from queue: {queue.Dequeue()}");
                    }
                    break;
                case "stack":
                    while (stack.Count > 0)
                    {
                        Console.WriteLine($"Removed from stack: {stack.Pop()}");
                    }
                    break;
            }
        }
    }
}
