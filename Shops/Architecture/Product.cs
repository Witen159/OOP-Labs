using System;
using Shops.Exception;

namespace Shops.Architecture
{
    public class Product
    {
        public Product(string productName, int numberOfProducts, int cost)
        {
            ProductName = productName;
            if (numberOfProducts <= 0 || cost <= 0)
                throw new IncorrectProductSpecificationsShopException();
            NumberOfProducts = numberOfProducts;
            Cost = cost;
        }

        public string ProductName { get; }
        public int NumberOfProducts { get; set; }
        public int Cost { get; set; }
    }
}