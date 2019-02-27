using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            IPhone6 iphone = new IPhone6() { Price = 5288};
            //訂閱事件
            iphone.PriceChanged += IPhone_Changed;
            iphone.Price = 2988; //事件觸發
            Console.ReadKey();
        }
        static void IPhone_Changed(decimal oldPrice, decimal newPrice)
        {
            Console.WriteLine("年底大促銷,原價{0}元,現價{1}元,快來搶購啊",oldPrice,newPrice);
        }
    }
}
