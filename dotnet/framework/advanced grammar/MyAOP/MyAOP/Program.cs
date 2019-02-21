using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
    class Program
    {
        static void Main(string[] args)
        {
            ProxyAOP proxyAOP = new ProxyAOP();
            proxyAOP.Show();
            Console.ReadKey();
        }
    }
}
