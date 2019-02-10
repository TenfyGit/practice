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
                Console.WriteLine("请输入第一个数!");
                numberOne = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入第二个数!");
                numberTwo = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入运算符!");
                operate = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("您输入的数字有问题!");
                Console.WriteLine(ex.Message);
            }
            IOperation operation = OperationFactory.CreateOperation(operate);
            double result = operation.GetResult(numberOne, numberTwo);
            Console.WriteLine("结果是"+result);
            Console.ReadKey();
        }
    }
}
