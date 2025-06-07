using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectE
{
    public interface IMathHelper
    {
            float CalculateSum(float firstNumber, float secondNumber);

            float CalculateDifference(float firstNumber, float secondNumber);

            float CalculateProduct(float firstNumber, float secondNumber);

            float CalculateQuotient(float firstNumber, float secondNumber);
    }
}
