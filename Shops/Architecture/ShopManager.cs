using System.Collections.Generic;

namespace Shops.Architecture
{
    public class ShopManager
    {
        private List<string> _availableProducts = new List<string>();
        private List<Shop> _shops = new List<Shop>();

        public Shop AddShop(string shopName, string shopAddress)
        {
            var newShop = new Shop(shopName, shopAddress);
            _shops.Add(newShop);
            return newShop;
        }

        public void RegisterProduct(string productName)
        {
            _availableProducts.Add(productName);
        }

        public Shop FindTheBestOffer(Order order)
        {
            Shop bestOfferShop = null;
            int minCost = int.MaxValue;
            foreach (Shop currentShop in _shops)
            {
                foreach (Product currentProduct in currentShop.GetAllProducts())
                {
                    if (currentProduct.ProductName == order.ProductName)
                    {
                        if (currentProduct.Cost < minCost && currentProduct.NumberOfProducts >= order.NumberOfProduct)
                        {
                            bestOfferShop = currentShop;
                            minCost = currentProduct.Cost;
                        }

                        break;
                    }
                }
            }

            return bestOfferShop;
        }

        public List<string> GetRegisteredProducts()
        {
            return _availableProducts;
        }
    }
}