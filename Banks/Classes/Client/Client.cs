using System;
using Banks.Tools;

namespace Banks.Classes.Client
{
    public class Client
    {
        public string Name { get; internal set; }
        public string Surname { get; internal set; }
        public string Address { get; internal set; }
        public int PassportNumber { get; internal set; }
        public bool Verification { get; internal set; }
        public int Id { get; internal set; }

        public void SetAddress(string address)
        {
            if (Address != null)
                throw new BankException("Address already added");
            Address = address;
            VerificationChek();
        }

        public void SetPassport(int passportNumber)
        {
            if (PassportNumber != 0)
                throw new BankException("Passport number already added");
            PassportNumber = passportNumber;
            VerificationChek();
        }

        private void VerificationChek()
        {
            Verification = Address != null && PassportNumber != 0;
        }
    }
}