using System.Collections.Generic;
using Shops.Exception;

namespace Shops.Entities
{
    public class Shop
    {
        private static int _currentShopId = 1;
        private List<Shelf> _allShelfs;
        public Shop(string name, string address)
        {
            Name = name;
            Address = address;
            Id = _currentShopId;
            _currentShopId++;
            Money = 100000;
            _allShelfs = new List<Shelf>();
        }

        public string Name { get; }
        public string Address { get; }
        public int Id { get; }
        public int Money { get; private set; }
        public IReadOnlyList<Shelf> AllShelfs => _allShelfs;

        public void AddProducts(List<Shelf> shelfs)
        {
            foreach (Shelf shelf in shelfs)
            {
                bool isProductPresent = false;
                foreach (Shelf shopsShelf in _allShelfs)
                {
                    if (shelf == shopsShelf)
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
                    if (shelf.ProductInShelf == currentOrder.Product)
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
            Money += price;
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
                if (shelf.ProductInShelf == product)
                    shelf.Cost = newCoast;
            }
        }

        public List<Shelf> GetAllShelfs()
        {
            return _allShelfs;
        }
    }
}