namespace ecommerce.Lib
{
    public class Product
    {
        public string Name { get; private set; }
        public ProductType Type { get; private set; }
        public decimal Price { get; private set; }

        public Product(string name, ProductType type, decimal price)
        {
            Name = name;
            Type = type;
            Price = price;
        }
    }
}
