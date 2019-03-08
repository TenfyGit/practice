using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStandardEvent
{
    
    public class IPhone6
    {
        private decimal price;
        public event EventHandler<PriceChangedEventArgs> PriceChanged;
        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            if (PriceChanged != null)
            {
                PriceChanged(this,e);
            }
        }
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
                if (PriceChanged != null)
                {
                    OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
                }
            }
        }
    }
}
