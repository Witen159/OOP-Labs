using System.Collections.Generic;
using Shops.Architecture;
using Shops.Exception;
using NUnit.Framework;

namespace Shops.Tests
{
    public class Tests
    {
        [Test]
        public void AddProductsToShop_PersonCanBuyProducts()
        {
            string nameOfProduct = "T-shirt";
            int numberOfTShirts = 10;
            int coastOfTShirts = 1700;
            int moneyOfPerson = 150000;
            int numberOfPurchasedTShirts = 5;
            
            Shop bestShop = ShopManager.AddShop("Taylor Swift Merch", "Primorsky Ave., 70/1");
            var fanOfTaylorSwift = new Person("Sasha Blashenkov", moneyOfPerson);
            
            ShopManager.RegisterProduct(nameOfProduct);
            bestShop.AddProducts(new List<Product>() {new Product(nameOfProduct, numberOfTShirts, coastOfTShirts)});
            bestShop.Purchase(fanOfTaylorSwift, new List<Order>() {new Order(nameOfProduct, numberOfPurchasedTShirts)});
            
            Assert.IsTrue(moneyOfPerson == fanOfTaylorSwift.Money + numberOfPurchasedTShirts * coastOfTShirts);
            Assert.IsTrue(bestShop.GetAllProducts()[0].NumberOfProducts == numberOfTShirts - numberOfPurchasedTShirts);
        }
        
        [Test]
        public void SetAndChangeCoast()
        {
            string nameOfProduct = "T-shirt";
            int oldCoast = 1700;
            int newCoat = 2500;
            
            Shop bestShop = ShopManager.AddShop("Taylor Swift Merch", "Primorsky Ave., 70/1");
            
            ShopManager.RegisterProduct(nameOfProduct);
            bestShop.AddProducts(new List<Product>() {new Product(nameOfProduct, 10, oldCoast)});
            Assert.IsTrue(bestShop.GetAllProducts()[0].Coast == oldCoast);
            
            bestShop.ChangeProductCoast(nameOfProduct, newCoat);
            Assert.IsTrue(bestShop.GetAllProducts()[0].Coast == newCoat);
        }
        
        [Test]
        public void FindShopWithBestOffer()
        {
            string nameOfProduct = "Milk";
            int defaultCoast = 50;
            int smallerCoast = 40;
            int smallestCoast = 30;
            int higherCoast = 60;
            
            Shop firstShop = ShopManager.AddShop("Pyaterochka", "Frunze 16");
            Shop secondShop = ShopManager.AddShop("Dixie", "Frunze 17");
            Shop thirdShop = ShopManager.AddShop("Crossroad", "Frunze 18");
            Shop fourthShop = ShopManager.AddShop("Ashan", "Frunze 19");
            
            ShopManager.RegisterProduct(nameOfProduct);
            firstShop.AddProducts(new List<Product>() {new Product(nameOfProduct, 6, defaultCoast)});
            secondShop.AddProducts(new List<Product>() {new Product(nameOfProduct, 5, smallerCoast)});
            thirdShop.AddProducts(new List<Product>() {new Product(nameOfProduct, 2, smallestCoast)}); // Smallest, but too little product
            fourthShop.AddProducts(new List<Product>() {new Product(nameOfProduct, 7, higherCoast)});
            
            Assert.IsTrue(ShopManager.FindTheBestOffer(new Order(nameOfProduct, 3)).ShopId == secondShop.ShopId);
        }
        
        [Test]
        public void PurchaseBatchOfProducts()
        {
            string firstProductName = "Milk";
            string secondProductName = "Bread";
            string thirdProductName = "Cheese";
            int defaultNumber = 5;
            int defaultCoast = 10;
            
            Shop shop = ShopManager.AddShop("Dixie", "Frunze 17");
            int oldShopMoney = shop.ShopMoney;
            int oldCustomerMoney = 100;
            var customer = new Person("Anchous", oldCustomerMoney);
            
            ShopManager.RegisterProduct(firstProductName);
            ShopManager.RegisterProduct(secondProductName);
            ShopManager.RegisterProduct(thirdProductName);
            shop.AddProducts(new List<Product>()
            {
                new Product(firstProductName, defaultNumber, defaultCoast),
                new Product(secondProductName, defaultNumber, defaultCoast),
                new Product(thirdProductName, defaultNumber, defaultCoast)
            });
            
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
            int price = defaultCoast * (2 + 3 + 4);
            
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