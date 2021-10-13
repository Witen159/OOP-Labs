using System.Collections.Generic;
using Shops.Entities;
using Shops.Exception;

namespace Shops.Manager
{
    public class ShopManager
    {
        private List<Product> _availableProducts = new List<Product>();
        private List<Shop> _shops = new List<Shop>();

        public Shop AddShop(string shopName, string shopAddress)
        {
            var newShop = new Shop(shopName, shopAddress);
            _shops.Add(newShop);
            return newShop;
        }

        public void RegisterProduct(Product product)
        {
            _availableProducts.Add(product);
        }

        public Shop FindTheBestOffer(Order order)
        {
            Shop bestOfferShop = null;
            int minCost = int.MaxValue;
            foreach (Shop currentShop in _shops)
            {
                foreach (Shelf currentShelf in currentShop.AllShelfs)
                {
                    if (currentShelf.ProductInShelf == order.Product)
                    {
                        if (currentShelf.Cost < minCost && currentShelf.NumberOfProducts >= order.NumberOfProduct)
                        {
                            bestOfferShop = currentShop;
                            minCost = currentShelf.Cost;
                        }

                        break;
                    }
                }
            }

            return bestOfferShop;
        }

        public void AddProductsToShop(Shop shop, List<Shelf> shelfs)
        {
            foreach (Shelf shelf in shelfs)
            {
                if (!_availableProducts.Contains(shelf.ProductInShelf))
                    throw new UnregisteredProductShopException();
            }

            shop.AddProducts(shelfs);
        }
    }
}