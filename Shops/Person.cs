using System;

namespace Shops
{
    public class Person
    {
        public Person(string name, int money)
        {
            Name = name;
            if (money < 0)
                throw new Exception();
            Money = money;
        }

        public string Name { get; }
        public int Money { get; }
    }
}