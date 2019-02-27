using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvent
{
    public delegate void PriceChangedHandle(decimal oldPrice,decimal newPrice);
    public class IPhone6
    {
        private decimal price;
        public event PriceChangedHandle PriceChanged;
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (price == value)
                {
                    return;
                }
                decimal oldPrice = price;
                price = value;
                //如果調用列表不為空,則觸發
                if (PriceChanged != null)
                {
                    PriceChanged(oldPrice, price);
                }
            }
        }
    }
}
