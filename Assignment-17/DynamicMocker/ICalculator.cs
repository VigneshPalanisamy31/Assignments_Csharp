namespace DynamicMocker
{
    public interface ICalculator
    {
        public string Name {  get; }   
        float Calculate(float x, float y);
    }
}
