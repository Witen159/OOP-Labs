using System.Collections.Generic;

namespace Shops.Architecture
{
    public static class ShopManager
    {
        private static List<string> _availableProducts = new List<string>();
        private static List<Shop> _shops = new List<Shop>();

        public static Shop AddShop(string shopName, string shopAddress)
        {
            var newShop = new Shop(shopName, shopAddress);
            _shops.Add(newShop);
            return newShop;
        }

        public static void RegisterProduct(string productName)
        {
            _availableProducts.Add(productName);
        }

        public static Shop FindTheBestOffer(Order order)
        {
            Shop bestOfferShop = null;
            int minCost = int.MaxValue;
            foreach (Shop currentShop in _shops)
            {
                foreach (Product currentProduct in currentShop.GetAllProducts())
                {
                    if (currentProduct.ProductName == order.ProductName)
                    {
                        if (currentProduct.Coast < minCost && currentProduct.NumberOfProducts >= order.NumberOfProduct)
                        {
                            bestOfferShop = currentShop;
                            minCost = currentProduct.Coast;
                        }

                        break;
                    }
                }
            }

            return bestOfferShop;
        }

        public static List<string> GetRegisteredProducts()
        {
            return _availableProducts;
        }
    }
}