using System;
using System.Collections.Generic;
using System.Linq;

namespace ecommerce.Lib
{
    public class Customer
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public decimal Balance { get; private set; }
        private HashSet<BoughtProduct> _boughtProducts { get; set; } = new HashSet<BoughtProduct>();
        public List<string> customerBoughtProducts => _boughtProducts.Select(product => product.Name).ToList();

        public Customer(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
            Balance = 0;
        }

        public void ChangeBalance(decimal amount)
        {
            Balance += amount;
        }

        public void AddProduct(BoughtProduct boughtProduct)
        {
            _boughtProducts.Add(boughtProduct);
        }

        public void RemoveProduct(BoughtProduct boughtProduct)
        {
            _boughtProducts.Remove(boughtProduct);
        }
    }
}