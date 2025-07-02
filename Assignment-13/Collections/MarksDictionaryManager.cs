namespace Collections
{
    internal class MarksDictionaryManager
    {
        private Dictionary<string, int> marks;
        public MarksDictionaryManager()
        {
            marks = new();
        }

        /// <summary>
        /// Displays menu to work with dictionaries
        /// </summary>
        public void UnderstandingDictionaries()
        {
            bool canExit = false;
            while (!canExit)
            {
                Console.Clear();
                Helper.WriteInColor("============Marks of Students============", ConsoleColor.Yellow);
                Helper.WriteInColor("\n1.Add\n2.Remove\n3.Display\n4.Exit", ConsoleColor.Yellow);
                int choice = Validator.GetValidInt("Enter the choice :");
                switch (choice)
                {
                    case 1:
                        AddStudentMark();
                        break;

                    case 2:
                        RemoveStudent();
                        break;

                    case 3:
                        DisplayMarks();
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
        /// Adds student marks to the mark list dictionary.
        /// </summary>
        public void AddStudentMark()
        {
            int studentsCount = Validator.GetValidInt("Enter the number of students :");
            for (int i = 0; i < studentsCount; i++)
            {
                marks.Add(Validator.GetValidString($"Enter the name of student {i + 1} :"), Validator.GetValidInt("Enter the mark :"));
            }
            Helper.WriteInColor("\nStudents added successfully", ConsoleColor.Green);
        }

        /// <summary>
        /// Removes student marks from the mark list dictionary.
        /// </summary>
        public void RemoveStudent()
        {
            string nameToBeRemoved = Validator.GetValidString("Enter the name to be removed :");
            if (marks.TryGetValue(nameToBeRemoved, out int mark))
            {
                Helper.WriteInColor($"\n{nameToBeRemoved}  :  {mark}", ConsoleColor.Green);
                Helper.WriteInColor("\nStudent deleted from List successfully..", ConsoleColor.Green);
                marks.Remove(nameToBeRemoved);
            }
            else
            {
                Helper.WriteInColor("\nStudent not found\nDelete failed...", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Displays student marks from the mark list dictionary.
        /// </summary>
        public void DisplayMarks()
        {
            if (marks.Count == 0)
            {
                Helper.WriteInColor("\nNo marks available", ConsoleColor.Red);
            }
            else
            {
                Helper.WriteInColor("Marks of students\n", ConsoleColor.Yellow);
                Helper.WriteInColor("\nStudent name :  Mark", ConsoleColor.Yellow);
                foreach (var mark in marks)
                {
                    Console.WriteLine($"{mark.Key}  :  {mark.Value}");
                }
            }
        }
    }
}
