using System;
using System.Collections.Generic;
using System.Xml;
using Shops.Exception;

namespace Shops.Architecture
{
    public class Shop
    {
        private static int _currentShopId = 1;
        private List<Shelf> _allShelfs;
        public Shop(string shopName, string address)
        {
            ShopName = shopName;
            Address = address;
            ShopId = _currentShopId;
            _currentShopId++;
            ShopMoney = 100000;
            _allShelfs = new List<Shelf>();
        }

        public string ShopName { get; }
        public string Address { get; }
        public int ShopId { get; }
        public int ShopMoney { get; private set; }

        public void AddProducts(List<Shelf> shelfs, ShopManager shopManager)
        {
            foreach (Shelf shelf in shelfs)
            {
                if (!shopManager.GetRegisteredProducts().Contains(shelf.ProductInShelf))
                    throw new UnregisteredProductShopException();

                bool isProductPresent = false;
                foreach (Shelf shopsShelf in _allShelfs)
                {
                    if (shelf.ProductInShelf.ProductName == shopsShelf.ProductInShelf.ProductName)
                    {
                        isProductPresent = true;
                        shopsShelf.NumberOfProducts += shelf.NumberOfProducts;
                    }
                }

                if (!isProductPresent)
                    _allShelfs.Add(shelf);
            }
        }

        public void Purchase(Person customer, List<Order> orders)
        {
            int price = 0;
            var changedShelfs = new List<Shelf>();
            foreach (Order currentOrder in orders)
            {
                bool isPurchaseCompleted = false;
                foreach (Shelf shelf in _allShelfs)
                {
                    if (shelf.ProductInShelf.ProductName == currentOrder.Product.ProductName)
                    {
                        if (shelf.NumberOfProducts < currentOrder.NumberOfProduct)
                            throw new InvalidPurchaseShopException();
                        price += currentOrder.NumberOfProduct * shelf.Cost;
                        changedShelfs.Add(shelf);
                        isPurchaseCompleted = true;
                        break;
                    }
                }

                if (!isPurchaseCompleted)
                    throw new InvalidPurchaseShopException();
            }

            if (price > customer.Money)
                throw new InvalidPurchaseShopException();
            ShopMoney += price;
            customer.Pay(price);

            for (int i = 0; i < orders.Count; i++)
            {
                changedShelfs[i].NumberOfProducts -= orders[i].NumberOfProduct;
            }
        }

        public void ChangeProductCost(Product product, int newCoast)
        {
            foreach (Shelf shelf in _allShelfs)
            {
                if (shelf.ProductInShelf.ProductName == product.ProductName)
                    shelf.Cost = newCoast;
            }
        }

        public List<Shelf> GetAllShelfs()
        {
            return _allShelfs;
        }
    }
}