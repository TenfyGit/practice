using System;
using System.Collections.Generic;
using System.Text;

namespace Operations.lib
{
    public class OperationAdd : IOperation
    {
        public double GetResult(double numberOne, double numberTwo)
        {
            return numberOne + numberTwo;
        }
    }
}
