using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareCalc
{
    public class BelowZeroException : Exception
    {
        public BelowZeroException() { }
        public BelowZeroException(string message) : base(message) { }

    }
 
    public class NotExistException : Exception
    {
        public NotExistException() { }
        public NotExistException(string message) : base(message) { }
    }
}
