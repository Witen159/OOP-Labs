using System;

namespace Shops.Architecture
{
    public class Product
    {
        public Product(string productName)
        {
            ProductName = productName;
        }

        public string ProductName { get; }
    }
}