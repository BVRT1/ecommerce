using System;
using ecommerce.Lib;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace ecommerce.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my ecommerce app");

            var platform = new Platform();

            var arthur = platform.AddCustomer("Arthur", "Williams");
            var sarah = platform.AddCustomer("Sarah", "Smith");

            var mouse = platform.AddProduct("Razer Deathadder", ProductType.Devices, 59);
            var pen = platform.AddProduct("BIC Pen", ProductType.Gadgets, 2);
            var tshirt = platform.AddProduct("Plain White T-shirt", ProductType.Devices, 12);

            arthur.ChangeBalance(80);
            sarah.ChangeBalance(20);


            platform.BuyProduct(mouse, arthur);
            platform.BuyProduct(tshirt, arthur);
            platform.BuyProduct(pen, sarah);
            var boughtTshirt = platform.BuyProduct(tshirt, sarah);
            platform.ReturnProduct(boughtTshirt, sarah);

            ShowCustomers(platform);
            SaveCustomersData(platform);
        }

        static void ShowCustomers(Platform platform)
        {
            Console.WriteLine("Customers:");
            foreach (var customer in platform.GetCustomers())
            {
                Console.WriteLine($" {customer.Firstname} {customer.Lastname} - Balance: {customer.Balance}");
                foreach(var product in customer.customerBoughtProducts)
                {
                    Console.WriteLine($"  - {product}");
                }
            }
        }

        static void SaveCustomersData(Platform platform)
        {
            foreach (var customer in platform.GetCustomers())
            {
                string customerData = JsonSerializer.Serialize(customer);
                File.WriteAllText($"{customer.Firstname}{customer.Lastname}.json", customerData);
            }
        }
    }
}
