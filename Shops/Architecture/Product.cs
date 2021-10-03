using System;
using Shops.Exception;

namespace Shops.Architecture
{
    public class Product
    {
        public Product(string productName, int numberOfProducts, int coast)
        {
            ProductName = productName;
            if (numberOfProducts <= 0 || coast <= 0)
                throw new IncorrectProductSpecificationsShopException();
            NumberOfProducts = numberOfProducts;
            Coast = coast;
        }

        public string ProductName { get; }
        public int NumberOfProducts { get; set; }
        public int Coast { get; set; }
    }
}