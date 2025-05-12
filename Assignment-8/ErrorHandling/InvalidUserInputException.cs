using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandling
{
    /// <summary>
    /// User defined custom exception
    /// </summary>
    public class InvalidUserInputException : Exception
    {
        public InvalidUserInputException(string message) 
            : base(message) { }
    }
}
