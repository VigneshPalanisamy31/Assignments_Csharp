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
            bool isExit = false;
            while (!isExit)
            {
                Console.Clear();
                Helper.WriteinYellow("============Queue of People============");
                Helper.WriteinYellow("\n1.Add\n2.Remove\n3.Display\n4.Exit");
                int choice = Validator.GetValidInt("choice");
                switch (choice)
                {
                    case 1: Enqueue(); break;
                    case 2: Dequeue(); break;
                    case 3: DisplayPeople(); break;
                    case 4:
                        isExit = true;
                        Console.WriteLine("Exiting"); break;
                    default:
                        Helper.WriteinRed("\nInvalid choice");
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
                people.Enqueue(Validator.GetValidString($"name of person {i+1}"));
            }
            Helper.WriteinGreen("\nQueue created successfully..");
        }

        /// <summary>
        /// Function to remove people from queue
        /// </summary>
        public void Dequeue()
        {
            if (people.Count == 0)
                Helper.WriteinRed("\nQueue is empty..");
            else
                Helper.WriteinGreen($"Dequeued person : {people.Dequeue().ToString()}");
                Helper.WriteinGreen("\nDequeue successful..");
        }

        /// <summary>
        /// Function to display people in the queue
        /// </summary>
        public void DisplayPeople()
        {
            if (people.Count == 0)
                Helper.WriteinRed("\nQueue Empty");
            else
                Helper.WriteinYellow("Queue Of People\n");
                foreach (var person in people)
                {
                    Console.WriteLine($"\n{person}");
                }
        }
    }
}
