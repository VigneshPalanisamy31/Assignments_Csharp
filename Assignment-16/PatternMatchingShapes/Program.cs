namespace PatternMatchingShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                List<Shape> shapes = new()
            {
                new Circle(5, "Red"),
                new Rectangle(4, 6, "Blue"),
                new Triangle(3, 7, "Green"),
                null
            };
                foreach (Shape shape in shapes)
                {
                    DisplayShapeDetails(shape);
                    Console.WriteLine(new string('-', 50));
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Displays details of the shape based on object
        /// </summary>
        /// <param name="shape"></param>
        static void DisplayShapeDetails(Shape shape)
        {
            switch (shape)
            {
                case Circle c:
                    Console.WriteLine($"Shape: Circle\nColor: {c.Colour}\nRadius: {c.Radius}\nArea: {c.CalculateArea():F2}");
                    break;

                case Rectangle r:
                    Console.WriteLine($"Shape: Rectangle\nColor: {r.Colour}\nWidth: {r.Width}, Height: {r.Height}\nArea: {r.CalculateArea():F2}");
                    break;

                case Triangle t:
                    Console.WriteLine($"Shape: Triangle\nColor: {t.Colour}\nBase: {t.BaseLength}, Height: {t.Height}\nArea: {t.CalculateArea():F2}");
                    break;

                case null:
                    Console.WriteLine("Null Type");
                    break;

                default:
                    Console.WriteLine("Unknown shape type.");
                    break;
            }
        }
    }
}

