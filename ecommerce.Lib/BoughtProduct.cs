using System;

namespace ecommerce.Lib
{
    public class BoughtProduct : Product
    {
        public DateTime BoughtOn { get; private set; }


        public BoughtProduct(string name, ProductType type, decimal price) : base(name, type, price)
        {
            BoughtOn = DateTime.Now;
        }
    }
}
