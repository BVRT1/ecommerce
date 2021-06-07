using Microsoft.VisualStudio.TestTools.UnitTesting;
using ecommerce.Lib;

namespace ecommerce.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void ChangingCustomerBalanceIsWorking()
        {
            var customer = new Customer("John", "Smith");

            customer.ChangeBalance(50);
            customer.ChangeBalance(-25);

            Assert.AreEqual(25, customer.Balance);
        }
    }
}
