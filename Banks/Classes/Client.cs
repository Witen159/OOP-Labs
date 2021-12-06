using System;

namespace Banks.Classes
{
    public class Client
    {
        public Client(string name, string surname, string address = null, int passportNumber = 0)
        {
            Name = name;
            Surname = surname;
            Address = address;
            PassportNumber = passportNumber;
            DoubtfulCheck();
        }

        public string Name { get; }
        public string Surname { get; }
        public string Address { get; private set; }
        public int PassportNumber { get; private set; }
        public bool Doubtful { get; private set; }

        public void SetAddress(string address)
        {
            if (Address != null)
                throw new Exception("Address already added");
            Address = address;
            DoubtfulCheck();
        }

        public void SetPassport(int passportNumber)
        {
            if (PassportNumber != 0)
                throw new Exception("Passport number already added");
            PassportNumber = passportNumber;
            DoubtfulCheck();
        }

        private void DoubtfulCheck()
        {
            Doubtful = Address == null || PassportNumber == 0;
        }
    }
}