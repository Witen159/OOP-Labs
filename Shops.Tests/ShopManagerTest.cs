using System.Collections.Generic;
using Shops.Exception;
using NUnit.Framework;
using Shops.Entities;
using Shops.Manager;

namespace Shops.Tests
{
    public class Tests
    {
        private ShopManager _shopManager;

        [SetUp]
        public void Setup()
        {
            //TODO: implement
            _shopManager = new ShopManager();
        }

        [Test]
        public void AddProductsToShop_PersonCanBuyProducts()
        {
            var product = new Product("T-shirt");
            int numberOfTShirts = 10;
            int costOfTShirts = 1700;
            int moneyOfPerson = 150000;
            int numberOfPurchasedTShirts = 5;
            
            Shop bestShop = _shopManager.AddShop("Taylor Swift Merch", "Primorsky Ave., 70/1");
            var fanOfTaylorSwift = new Person("Sasha Blashenkov", moneyOfPerson);
            
            _shopManager.RegisterProduct(product);
            _shopManager.AddProductsToShop(bestShop,new List<Shelf>() {new Shelf(product, numberOfTShirts, costOfTShirts)});
            bestShop.Purchase(fanOfTaylorSwift, new List<Order>() {new Order(product, numberOfPurchasedTShirts)});
            
            Assert.IsTrue(moneyOfPerson == fanOfTaylorSwift.Money + numberOfPurchasedTShirts * costOfTShirts);
            Assert.IsTrue(bestShop.AllShelfs[0].NumberOfProducts == numberOfTShirts - numberOfPurchasedTShirts);
        }
        
        [Test]
        public void SetAndChangeCost()
        {
            var product = new Product("T-shirt");
            int oldCost = 1700;
            int newCost = 2500;
            
            Shop bestShop = _shopManager.AddShop("Taylor Swift Merch", "Primorsky Ave., 70/1");
            
            _shopManager.RegisterProduct(product);
            _shopManager.AddProductsToShop(bestShop, new List<Shelf>() {new Shelf(product, 10, oldCost)});
            Assert.IsTrue(bestShop.AllShelfs[0].Cost == oldCost);
            
            bestShop.ChangeProductCost(product, newCost);
            Assert.IsTrue(bestShop.AllShelfs[0].Cost == newCost);
        }
        
        [Test]
        public void FindShopWithBestOffer()
        {
            var product = new Product("Milk");
            int defaultCost = 50;
            int smallerCost = 40;
            int smallestCost = 30;
            int higherCost = 60;
            
            Shop firstShop = _shopManager.AddShop("Pyaterochka", "Frunze 16");
            Shop secondShop = _shopManager.AddShop("Dixie", "Frunze 17");
            Shop thirdShop = _shopManager.AddShop("Crossroad", "Frunze 18");
            Shop fourthShop = _shopManager.AddShop("Ashan", "Frunze 19");
            
            _shopManager.RegisterProduct(product);
            _shopManager.AddProductsToShop(firstShop, new List<Shelf>() {new Shelf(product, 6, defaultCost)});
            _shopManager.AddProductsToShop(secondShop, new List<Shelf>() {new Shelf(product, 5, smallerCost)});
            _shopManager.AddProductsToShop(thirdShop, new List<Shelf>() {new Shelf(product, 2, smallestCost)}); // Smallest, but too little product
            _shopManager.AddProductsToShop(fourthShop, new List<Shelf>() {new Shelf(product, 7, higherCost)});
            
            Assert.IsTrue(_shopManager.FindTheBestOffer(new Order(product, 3)).Id == secondShop.Id);
        }
        
        [Test]
        public void PurchaseBatchOfProducts()
        {
            var firstProduct = new Product("Milk");
            var secondProduct = new Product("Bread");
            var thirdProduct = new Product("Cheese");
            int defaultNumber = 5;
            int defaultCost = 10;
            
            Shop shop = _shopManager.AddShop("Dixie", "Frunze 17");
            int oldShopMoney = shop.Money;
            int oldCustomerMoney = 100;
            var customer = new Person("Anchous", oldCustomerMoney);
            
            _shopManager.RegisterProduct(firstProduct);
            _shopManager.RegisterProduct(secondProduct);
            _shopManager.RegisterProduct(thirdProduct);
            _shopManager.AddProductsToShop(shop, new List<Shelf>()
            {
                new Shelf(firstProduct, defaultNumber, defaultCost),
                new Shelf(secondProduct, defaultNumber, defaultCost),
                new Shelf(thirdProduct, defaultNumber, defaultCost)
            });
            
            // Not enough money
            Assert.Catch<ShopException>(() =>
            {
                shop.Purchase(customer, new List<Order>()
                {
                    new Order(firstProduct, defaultNumber),
                    new Order(secondProduct, defaultNumber),
                    new Order(thirdProduct, defaultNumber)
                });
            });
            
            // Not enough products
            Assert.Catch<ShopException>(() =>
            {
                shop.Purchase(customer, new List<Order>()
                {
                    new Order(firstProduct, defaultNumber + 1)
                });
            });
            
            shop.Purchase(customer, new List<Order>()
            {
                new Order(firstProduct, 2),
                new Order(secondProduct, 3),
                new Order(thirdProduct, 4)
            });
            int price = defaultCost * (2 + 3 + 4);
            
            Assert.IsTrue(shop.Money == oldShopMoney + price);
            Assert.IsTrue(customer.Money == oldCustomerMoney - price);

            var newNumberOfProducts = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                newNumberOfProducts.Add(shop.AllShelfs[i].NumberOfProducts);
            }
            Assert.IsTrue(newNumberOfProducts[0] == defaultNumber - 2 
                          && newNumberOfProducts[1] == defaultNumber - 3 
                          && newNumberOfProducts[2] == defaultNumber - 4);
        }
    }
}