namespace Collections
{
    internal class MarksDictionaryManager
    {
        Dictionary<string,int> marks = new Dictionary<string,int>();
        /// <summary>
        /// Display menu to work with dictionaries
        /// </summary>
        public void UnderstandingDictionaries()
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.Clear();
                Helper.WriteinYellow("============Marks of Students============");
                Helper.WriteinYellow("\n1.Add\n2.Remove\n3.Display\n4.Exit");
                int choice = Validator.GetValidInt("choice");
                switch (choice)
                {
                    case 1: AddStudentMark(); break;
                    case 2: RemoveStudent(); break;
                    case 3: DisplayMarks(); break;
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
        /// Function to add student marks to the mark list dictionary.
        /// </summary>
        public void AddStudentMark()
        {
            int bookCount = Validator.GetValidInt("number of students");
            for (int i = 0; i < bookCount; i++)
            {
                marks.Add(Validator.GetValidString($"name of student {i + 1}"),Validator.GetValidInt("mark"));
            }
           Helper.WriteinGreen("\nStudents added successfully");
        }

        /// <summary>
        /// Function to remove student marks from the mark list dictionary.
        /// </summary>
        public void RemoveStudent()
        {
            string nameToBeRemoved = Validator.GetValidString("name to be removed");
            if (marks.TryGetValue(nameToBeRemoved,out int mark))
            {
                Helper.WriteinGreen($"\n{nameToBeRemoved}  :  {mark}");
                Helper.WriteinGreen("\nStudent deleted from List successfully..");
                marks.Remove(nameToBeRemoved);
            }
            else
                Helper.WriteinRed("\nStudent not found\nDelete failed...");
        }

        /// <summary>
        /// Function to display student marks from the mark list dictionary.
        /// </summary>
        public void DisplayMarks()
        {
            if (marks.Count == 0)
               Helper.WriteinRed("\nNo marks available");
            else
            {
               Helper.WriteinYellow("Marks of students\n");
               Helper.WriteinYellow("\nStudent name :  Mark");
                foreach (var mark in marks)
                {
                    Console.WriteLine($"{mark.Key}  :  {mark.Value}");
                }
            }
        }
    }
}
