using Operations.lib;
using System;

namespace Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberOne = 0;
            double numberTwo = 0;
            string operate = "";
            try
            {
                Console.WriteLine("Please enter the first number!");
                numberOne = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Please enter the second number!");
                numberTwo = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Please enter an operator!");
                operate = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is a problem with the number you entered!");
                Console.WriteLine(ex.Message);
            }
            IOperation operation = OperationFactory.CreateOperation(operate);
            double result = operation.GetResult(numberOne, numberTwo);
            Console.WriteLine("The Result is "+result);
            Console.ReadKey();
        }
    }
}
