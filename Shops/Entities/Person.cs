using Shops.Exception;

namespace Shops.Entities
{
    public class Person
    {
        public Person(string name, int money)
        {
            Name = name;
            if (money < 0)
                throw new InvalidPersonMoneyShopException();
            Money = money;
        }

        public string Name { get; }
        public int Money { get; private set; }

        public void Pay(int price)
        {
            if (price > Money)
                throw new InvalidPersonMoneyShopException();
            Money -= price;
        }

        public void TopUpAccount(int depositAmount)
        {
            Money += depositAmount;
        }
    }
}