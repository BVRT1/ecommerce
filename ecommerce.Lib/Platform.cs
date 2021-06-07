using ecommerce.Lib.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ecommerce.Lib
{
    public class Platform
    {
        private HashSet<Product> _products { get; set; } = new HashSet<Product>();
        private HashSet<Customer> _customers { get; set; } = new HashSet<Customer>();
        public List<string> customersList => _customers.Select(customer => customer.Firstname).ToList();

        public Product AddProduct(string name, ProductType type, decimal price)
        {
            var product = new Product(name, type, price);

            _products.Add(product);

            return product;
        }

        public Customer AddCustomer(string firstname, string lastname)
        {
            var customer = new Customer(firstname, lastname);
            _customers.Add(customer);
            return customer;
        }

        public BoughtProduct BuyProduct(Product product, Customer customer)
        {
            if (!_products.Contains(product))
            {
                throw new ProductDoesNotExist();
            }
            else if (product.Price > customer.Balance)
            {
                throw new CannotBuyWhenBalanceNotSufficient();
            }
            else
            {
                customer.ChangeBalance(-product.Price);
                BoughtProduct boughtProduct = new BoughtProduct(product.Name, product.Type, product.Price);
                customer.AddProduct(boughtProduct);
                return boughtProduct;
            }
        }

        public void ReturnProduct(BoughtProduct boughtProduct, Customer customer)
        {
            customer.RemoveProduct(boughtProduct);
            customer.ChangeBalance(boughtProduct.Price);
        }

        public HashSet<Customer> GetCustomers()
        {
            return _customers;
        }

    }
}
