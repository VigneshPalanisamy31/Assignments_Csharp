namespace Collections
{
    internal class PeopleManager
    {
        private Queue<string> _people;
        public PeopleManager()
        {
            _people = new();
        }

        /// <summary>
        /// Displays menu to work with queues
        /// </summary>
        public void ManagePeopleQueue()
        {
            bool canExit = false;
            while (!canExit)
            {
                Console.Clear();
                Helper.WriteInColor("============Queue of People============", ConsoleColor.Yellow);
                Helper.WriteInColor("\n1.Add\n2.Remove\n3.Display\n4.Exit", ConsoleColor.Yellow);
                int choice = Validator.GetValidInteger("Enter the choice :");
                switch (choice)
                {
                    case 1:
                        Enqueue();
                        break;

                    case 2:
                        Dequeue();
                        break;

                    case 3:
                        DisplayPeople();
                        break;

                    case 4:
                        canExit = true;
                        Console.WriteLine("Exiting");
                        break;

                    default:
                        Helper.WriteInColor("\nInvalid choice", ConsoleColor.Red);
                        break;
                }
                Console.WriteLine("\nPress any key to continue..");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Adds people to the queue
        /// </summary>
        public void Enqueue()
        {
            Console.WriteLine("Enter the number of people to be queued...");
            int queueSize = Validator.GetValidInteger("Enter the queue size :");
            for (int i = 0; i < queueSize; i++)
            {
                _people.Enqueue(Validator.GetValidString($"Enter the name of person {i + 1} :"));
            }
            Helper.WriteInColor("\nQueue created successfully..", ConsoleColor.Green);
        }

        /// <summary>
        /// Removes people from queue
        /// </summary>
        public void Dequeue()
        {
            if (!_people.Any())
            {
                Helper.WriteInColor("\nQueue is empty..", ConsoleColor.Red);
            }
            else
            {
                Helper.WriteInColor($"Dequeued person : {_people.Dequeue().ToString()}", ConsoleColor.Green);
                Helper.WriteInColor("\nDequeue successful..", ConsoleColor.Green);
            }
        }

        /// <summary>
        /// Displays people in the queue
        /// </summary>
        public void DisplayPeople()
        {
            if (!_people.Any())
            {
                Helper.WriteInColor("\nQueue is empty", ConsoleColor.Red);
            }
            else
            {
                Helper.WriteInColor("Queue Of People\n", ConsoleColor.Yellow);
                foreach (string person in _people)
                {
                    Console.WriteLine($"\n{person}");
                }
            }
        }
    }
}
