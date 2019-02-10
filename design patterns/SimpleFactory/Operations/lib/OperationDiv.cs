using System;
using System.Collections.Generic;
using System.Text;

namespace Operations.lib
{
    public class OperationDiv : IOperation
    {
        public double GetResult(double numberOne, double numberTwo)
        {
            if (numberTwo == 0)
            {
                throw new Exception("分母不能为0");
            }
            return numberOne / numberTwo;
        }
    }
}
