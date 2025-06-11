namespace PatternMatchingShapes
{
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(double radius, string colour)
        {
            Radius = radius;
            Colour = colour;
        }
        public override double CalculateArea() => Math.PI * Radius * Radius;
    }
}
