using System.Collections.Generic;

namespace Shops
{
    public class ShopManager
    {
        private List<Product> _availableProducts = new List<Product>();
        private List<Shop> _shops = new List<Shop>();
        public ShopManager()
        {
        }

        public Shop AddShop(string shopName, string shopAdress)
        {
            var newShop = new Shop(shopName, shopAdress);
            _shops.Add(newShop);
            return newShop;
        }

        public Product RegisterProduct(string productName)
        {
            Product newProduct = new Product(productName);
            _availableProducts.Add(newProduct);
            return newProduct;
        }

        public Shop FindTheBestOffer(Product product, int numberOfProducts)
        {
            return;
        }
    }
}