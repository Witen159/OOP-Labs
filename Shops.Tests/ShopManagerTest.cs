using System.Collections.Generic;
using Shops.Architecture;
using Shops.Exception;
using NUnit.Framework;

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
            string nameOfProduct = "T-shirt";
            int numberOfTShirts = 10;
            int costOfTShirts = 1700;
            int moneyOfPerson = 150000;
            int numberOfPurchasedTShirts = 5;
            
            Shop bestShop = _shopManager.AddShop("Taylor Swift Merch", "Primorsky Ave., 70/1");
            var fanOfTaylorSwift = new Person("Sasha Blashenkov", moneyOfPerson);
            
            _shopManager.RegisterProduct(nameOfProduct);
            bestShop.AddProducts(new List<Product>() {new Product(nameOfProduct, numberOfTShirts, costOfTShirts)}, _shopManager);
            bestShop.Purchase(fanOfTaylorSwift, new List<Order>() {new Order(nameOfProduct, numberOfPurchasedTShirts)});
            
            Assert.IsTrue(moneyOfPerson == fanOfTaylorSwift.Money + numberOfPurchasedTShirts * costOfTShirts);
            Assert.IsTrue(bestShop.GetAllProducts()[0].NumberOfProducts == numberOfTShirts - numberOfPurchasedTShirts);
        }
        
        [Test]
        public void SetAndChangeCost()
        {
            string nameOfProduct = "T-shirt";
            int oldCost = 1700;
            int newCoat = 2500;
            
            Shop bestShop = _shopManager.AddShop("Taylor Swift Merch", "Primorsky Ave., 70/1");
            
            _shopManager.RegisterProduct(nameOfProduct);
            bestShop.AddProducts(new List<Product>() {new Product(nameOfProduct, 10, oldCost)}, _shopManager);
            Assert.IsTrue(bestShop.GetAllProducts()[0].Cost == oldCost);
            
            bestShop.ChangeProductCost(nameOfProduct, newCoat);
            Assert.IsTrue(bestShop.GetAllProducts()[0].Cost == newCoat);
        }
        
        [Test]
        public void FindShopWithBestOffer()
        {
            string nameOfProduct = "Milk";
            int defaultCost = 50;
            int smallerCost = 40;
            int smallestCost = 30;
            int higherCost = 60;
            
            Shop firstShop = _shopManager.AddShop("Pyaterochka", "Frunze 16");
            Shop secondShop = _shopManager.AddShop("Dixie", "Frunze 17");
            Shop thirdShop = _shopManager.AddShop("Crossroad", "Frunze 18");
            Shop fourthShop = _shopManager.AddShop("Ashan", "Frunze 19");
            
            _shopManager.RegisterProduct(nameOfProduct);
            firstShop.AddProducts(new List<Product>() {new Product(nameOfProduct, 6, defaultCost)}, _shopManager);
            secondShop.AddProducts(new List<Product>() {new Product(nameOfProduct, 5, smallerCost)}, _shopManager);
            thirdShop.AddProducts(new List<Product>() {new Product(nameOfProduct, 2, smallestCost)}, _shopManager); // Smallest, but too little product
            fourthShop.AddProducts(new List<Product>() {new Product(nameOfProduct, 7, higherCost)}, _shopManager);
            
            Assert.IsTrue(_shopManager.FindTheBestOffer(new Order(nameOfProduct, 3)).ShopId == secondShop.ShopId);
        }
        
        [Test]
        public void PurchaseBatchOfProducts()
        {
            string firstProductName = "Milk";
            string secondProductName = "Bread";
            string thirdProductName = "Cheese";
            int defaultNumber = 5;
            int defaultCost = 10;
            
            Shop shop = _shopManager.AddShop("Dixie", "Frunze 17");
            int oldShopMoney = shop.ShopMoney;
            int oldCustomerMoney = 100;
            var customer = new Person("Anchous", oldCustomerMoney);
            
            _shopManager.RegisterProduct(firstProductName);
            _shopManager.RegisterProduct(secondProductName);
            _shopManager.RegisterProduct(thirdProductName);
            shop.AddProducts(new List<Product>()
            {
                new Product(firstProductName, defaultNumber, defaultCost),
                new Product(secondProductName, defaultNumber, defaultCost),
                new Product(thirdProductName, defaultNumber, defaultCost)
            }, _shopManager);
            
            // Not enough money
            Assert.Catch<ShopException>(() =>
            {
                shop.Purchase(customer, new List<Order>()
                {
                    new Order(firstProductName, defaultNumber),
                    new Order(secondProductName, defaultNumber),
                    new Order(thirdProductName, defaultNumber)
                });
            });
            
            // Not enough products
            Assert.Catch<ShopException>(() =>
            {
                shop.Purchase(customer, new List<Order>()
                {
                    new Order(firstProductName, defaultNumber + 1)
                });
            });
            
            shop.Purchase(customer, new List<Order>()
            {
                new Order(firstProductName, 2),
                new Order(secondProductName, 3),
                new Order(thirdProductName, 4)
            });
            int price = defaultCost * (2 + 3 + 4);
            
            Assert.IsTrue(shop.ShopMoney == oldShopMoney + price);
            Assert.IsTrue(customer.Money == oldCustomerMoney - price);

            var newNumberOfProducts = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                newNumberOfProducts.Add(shop.GetAllProducts()[i].NumberOfProducts);
            }
            Assert.IsTrue(newNumberOfProducts[0] == defaultNumber - 2 
                          && newNumberOfProducts[1] == defaultNumber - 3 
                          && newNumberOfProducts[2] == defaultNumber - 4);
        }
    }
}