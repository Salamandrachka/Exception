using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    public class MatrixException : SystemException
    {
        public MatrixException(string message) : base(message)
        {
        }
    }
}
   