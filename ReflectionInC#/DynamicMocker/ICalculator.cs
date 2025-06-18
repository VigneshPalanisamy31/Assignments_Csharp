using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMocker
{
    public interface ICalculator
    {
        public string Name {  get; }   
        float Calculate(float x, float y);
    }
}
