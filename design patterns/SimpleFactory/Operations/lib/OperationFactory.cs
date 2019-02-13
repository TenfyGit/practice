using System;
using System.Collections.Generic;
using System.Text;

namespace Operations.lib
{
    public class OperationFactory
    {
        public static IOperation CreateOperation(string operate)
        {
            IOperation operation = null;
            switch (operate)
            {
                case "+":
                    operation = new OperationAdd();
                    break;
                case "-":
                    operation = new OperationSub();
                    break;
                case "*":
                    operation = new OperationMul();
                    break;
                case "/":
                    operation = new OperationDiv();
                    break;
                default:
                    throw new Exception("No such specified operator");
            }
            return operation;
        }
    }
}
