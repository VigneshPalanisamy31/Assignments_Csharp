namespace PatternMatchingShapes
{
    public abstract class Shape
    {
        public string Colour { get; set; }
        public abstract double CalculateArea();
    }
}
