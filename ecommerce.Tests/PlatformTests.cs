using System;
using System.Linq;
using ecommerce.Lib;
using ecommerce.Lib.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ecommerce.Tests
{
    [TestClass]
    public class PlatformTests
    {
        [TestMethod]
        public void CanBuyAndReturnAProduct()
        {
            var platform = new Platform();
            var customer = platform.AddCustomer("John", "Smith");
            customer.ChangeBalance(50);
            var pen = platform.AddProduct("Keyboard", ProductType.Devices, 20);
            var boughtPen = platform.BuyProduct(pen, customer);
            platform.ReturnProduct(boughtPen, customer);

            Assert.IsFalse(customer.customerBoughtProducts.Any());
        }

        [TestMethod]
        public void CannotBuyWithoutEnoughBalance()
        {
            var platform = new Platform();
            var customer = platform.AddCustomer("John", "Smith");
            customer.ChangeBalance(1);
            var pen = platform.AddProduct("Keyboard", ProductType.Devices, 20);
            Action buyingProduct = () => platform.BuyProduct(pen, customer);

            Assert.ThrowsException<CannotBuyWhenBalanceNotSufficient>(buyingProduct);
        }
    }
}
