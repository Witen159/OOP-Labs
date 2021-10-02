using System;

namespace Shops
{
    public class Product
    {
        public Product(string productName, int numberOfProducts, int coast)
        {
            ProductName = productName;
            if (numberOfProducts <= 0 || coast <= 0)
                throw new Exception();
            NumberOfProducts = numberOfProducts;
            Coast = coast;
        }

        public string ProductName { get; }
        public int NumberOfProducts { get; set; }
        public int Coast { get; set; }
    }
}