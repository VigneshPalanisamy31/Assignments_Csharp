namespace PatternMatchingShapes
{
    public class Triangle : Shape
    {
        public double BaseLength { get; set; }
        public double Height { get; set; }
        public Triangle(double baseLength, double height, string colour)
        {
            BaseLength = baseLength;
            Height = height;
            Colour = colour;
        }
        public override double CalculateArea() => 0.5 * BaseLength * Height;
    }
}
