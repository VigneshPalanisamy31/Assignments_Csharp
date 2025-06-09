using LINQ.Utilities;
namespace LINQ.Controller.QueryHandler
{
    internal class LINQonArray
    {
        /// <summary>
        /// Function to display second highest number and pairs that sum up to given target .
        /// </summary>
        public static void DisplayPairsSummingUptoTarget()
        {
            int arraySize = Validator.GetValidNumber("array size ");
            float[] array = new float[arraySize];
            Console.WriteLine("Enter the array elements");
            for (int i = 0; i < arraySize; i++)
            {
                if(!float.TryParse(Console.ReadLine(), out array[i]))
                {
                    Console.WriteLine("Operation terminated due to invalid input\nExpected input:Valid Integers...");
                    return;
                }
            }
            if (arraySize < 2)
            {
                Console.WriteLine("Insufficient Elements to find second highest element");
                return;
            }
            try
            {
                float secondHighest = array.OrderByDescending(n => n).Distinct().Skip(1).First();
                Helper.WriteInGreen("Second Highest Number : " + secondHighest);
            }
            catch(Exception e)
            {
                Console.WriteLine("Insufficient Distinct Elements to find second highest element");
            }
            float target = Validator.GetValidFloat("Target sum:");
            var TargetPairs=array.SelectMany((value,index)=>array.Skip(index+1),
                                             (first,second)=>new { first, second }).Where(pair=>pair.first+pair.second==target).Distinct().ToList();
            Helper.WriteInYellow("Pairs summing up to target :");
            foreach (var pair in TargetPairs)
            {
                Console.WriteLine($"({pair.first},{pair.second})");
            }
        }
    }
}
