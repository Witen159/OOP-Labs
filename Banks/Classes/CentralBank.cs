using System.Collections.Generic;

namespace Banks.Classes
{
    public class CentralBank
    {
        private List<Bank.Bank> _banks;

        public CentralBank()
        {
            _banks = new List<Bank.Bank>();
        }

        public Bank.Bank RegisterNewBank(int operationLimit)
        {
            var newBank = new Bank.Bank(operationLimit);
            _banks.Add(newBank);
            return newBank;
        }
    }
}