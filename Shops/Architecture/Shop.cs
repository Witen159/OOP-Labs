using System;
using System.Collections.Generic;
using System.Xml;
using Shops.Exception;

namespace Shops.Architecture
{
    public class Shop
    {
        private static int _currentShopId = 1;
        private List<Product> _allProducts;
        public Shop(string shopName, string address)
        {
            ShopName = shopName;
            Address = address;
            ShopId = _currentShopId;
            _currentShopId++;
            ShopMoney = 100000;
            _allProducts = new List<Product>();
        }

        public string ShopName { get; }
        public string Address { get; }
        public int ShopId { get; }
        public int ShopMoney { get; private set; }

        public void AddProducts(List<Product> products, ShopManager shopManager)
        {
            foreach (Product product in products)
            {
                if (!shopManager.GetRegisteredProducts().Contains(product.ProductName))
                    throw new UnregisteredProductShopException();

                bool isProductPresent = false;
                foreach (Product shopsProduct in _allProducts)
                {
                    if (product.ProductName == shopsProduct.ProductName)
                    {
                        isProductPresent = true;
                        shopsProduct.NumberOfProducts += product.NumberOfProducts;
                    }
                }

                if (!isProductPresent)
                    _allProducts.Add(product);
            }
        }

        public void Purchase(Person customer, List<Order> orders)
        {
            int price = 0;
            var changedProducts = new List<Product>();
            foreach (Order currentOrder in orders)
            {
                bool isPurchaseCompleted = false;
                foreach (Product product in _allProducts)
                {
                    if (product.ProductName == currentOrder.ProductName)
                    {
                        if (product.NumberOfProducts < currentOrder.NumberOfProduct)
                            throw new InvalidPurchaseShopException();
                        price += currentOrder.NumberOfProduct * product.Cost;
                        changedProducts.Add(product);
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
                changedProducts[i].NumberOfProducts -= orders[i].NumberOfProduct;
            }
        }

        public void ChangeProductCost(string productName, int newCoast)
        {
            foreach (Product product in _allProducts)
            {
                if (product.ProductName == productName)
                    product.Cost = newCoast;
            }
        }

        public List<Product> GetAllProducts()
        {
            return _allProducts;
        }
    }
}