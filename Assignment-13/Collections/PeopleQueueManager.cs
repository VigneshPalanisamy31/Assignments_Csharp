namespace Collections
{
    internal class PeopleQueueManager
    {
        Queue<string> people = new Queue<string>();

        /// <summary>
        /// Displays menu to work with queues
        /// </summary>
        public void WorkingWithQueues()
        {
            bool canExit = false;
            while (!canExit)
            {
                Console.Clear();
                Helper.WriteInColor("============Queue of People============", ConsoleColor.Yellow);
                Helper.WriteInColor("\n1.Add\n2.Remove\n3.Display\n4.Exit", ConsoleColor.Yellow);
                int choice = Validator.GetValidInt("choice");
                switch (choice)
                {
                    case 1: Enqueue(); break;
                    case 2: Dequeue(); break;
                    case 3: DisplayPeople(); break;
                    case 4:
                        canExit = true;
                        Console.WriteLine("Exiting"); break;
                    default:
                        Helper.WriteInColor("\nInvalid choice", ConsoleColor.Red);
                        break;
                }
                Console.WriteLine("\nPress any key to continue..");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Function to add people to the queue
        /// </summary>
        public void Enqueue()
        {
            Console.WriteLine("Enter the number of people to be queued...");
            int queueSize = Validator.GetValidInt("size");
            for (int i = 0; i < queueSize; i++)
            {
                people.Enqueue(Validator.GetValidString($"name of person {i + 1}"));
            }
            Helper.WriteInColor("\nQueue created successfully..", ConsoleColor.Green);
        }

        /// <summary>
        /// Function to remove people from queue
        /// </summary>
        public void Dequeue()
        {
            if (people.Count == 0)
                Helper.WriteInColor("\nQueue is empty..", ConsoleColor.Red);
            else
            {
                Helper.WriteInColor($"Dequeued person : {people.Dequeue().ToString()}", ConsoleColor.Green);
                Helper.WriteInColor("\nDequeue successful..", ConsoleColor.Green);
            }
        }

        /// <summary>
        /// Function to display people in the queue
        /// </summary>
        public void DisplayPeople()
        {
            if (people.Count == 0)
                Helper.WriteInColor("\nQueue is empty", ConsoleColor.Red);
            else
                Helper.WriteInColor("Queue Of People\n", ConsoleColor.Yellow);
            foreach (string person in people)
            {
                Console.WriteLine($"\n{person}");
            }
        }
    }
}
