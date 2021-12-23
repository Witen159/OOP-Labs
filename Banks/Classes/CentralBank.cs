using System.Collections.Generic;
using Banks.Classes.Account;
using Banks.Classes.Bank;

namespace Banks.Classes
{
    public class CentralBank
    {
        private List<Bank.Bank> _banks = new List<Bank.Bank>();

        public CentralBank()
        {
        }

        public Bank.Bank RegisterNewBank(int operationLimit, PercentAmount percentAmount)
        {
            var newBank = new Bank.Bank(operationLimit, percentAmount);
            _banks.Add(newBank);
            return newBank;
        }

        public void Transfer(AccountDecorator fromAccount, AccountDecorator toAccount, double amountOfMoney)
        {
        }
    }
}