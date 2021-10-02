using System.Collections.Generic;

namespace Shops
{
    public class ShopManager
    {
        private List<string> _availableProducts;
        private List<Shop> _shops;
        public ShopManager()
        {
            _availableProducts = new List<string>();
            _shops = new List<Shop>();
        }

        public Shop AddShop(string shopName, string shopAdress)
        {
            var newShop = new Shop(shopName, shopAdress);
            _shops.Add(newShop);
            return newShop;
        }

        public void RegisterProduct(string productName)
        {
            _availableProducts.Add(productName);
        }

        public Shop FindTheBestOffer(Product product, int numberOfProducts)
        {
            return;
        }
    }
}