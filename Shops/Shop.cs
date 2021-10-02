using System.Collections.Generic;

namespace Shops
{
    public class Shop
    {
        private static int _currentShopId = 1;
        private List<Product> _allProducts;
        public Shop(string shopName, string adress)
        {
            ShopName = shopName;
            Adress = adress;
            ShopId = _currentShopId;
            _currentShopId++;
            ShopMoney = 100000;
            _allProducts = new List<Product>();
        }

        public string ShopName { get; }
        public string Adress { get; }
        public int ShopId { get; }
        public int ShopMoney { get; }

        public void AddProducts(List<Product> products)
        {
            foreach (Product product in products)
            {
                bool isProductPresent = false;
                foreach (Product shopsProduct in _allProducts)
                {
                    if (product.ProductName == shopsProduct.ProductName)
                    {
                        isProductPresent = true;
                        shopsProduct.NumberOfProducts += product.NumberOfProducts;
                    }

                    if (!isProductPresent)
                        _allProducts.Add(product);
                }
            }
        }

        public void Buy(Person customer, Product product, int numberOfProducts)
        {
        }
    }
}