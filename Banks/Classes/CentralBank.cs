using System;
using System.Collections.Generic;
using Banks.Classes.Account;
using Banks.Classes.Bank;
using Banks.Tools;

namespace Banks.Classes
{
    public sealed class CentralBank
    {
        private static CentralBank _instance;
        private List<Bank.Bank> _banks = new List<Bank.Bank>();

        private CentralBank(DateTime currentTime)
        {
            CurrentTime = currentTime;
        }

        public DateTime CurrentTime { get; private set; }
        public IReadOnlyList<Bank.Bank> Banks => _banks;

        public static CentralBank GetInstance(DateTime currentTime)
        {
            return _instance ??= new CentralBank(currentTime);
        }

        public Bank.Bank RegisterNewBank(string name, int operationLimit, int creditNegativeLimit, PercentAmount depositInterestOnTheBalance, double debitInterestOnTheBalance, double commission)
        {
            var newBank = new Bank.Bank(name, operationLimit, creditNegativeLimit, depositInterestOnTheBalance, debitInterestOnTheBalance, commission, CurrentTime);
            _banks.Add(newBank);
            return newBank;
        }

        public DateTime GetCurrentTime()
        {
            return _instance.CurrentTime;
        }

        public void NewDate(DateTime newDate)
        {
            if ((newDate - CurrentTime).Days < 1)
                throw new BankException("New date should be at least next day");
            _instance.CurrentTime = newDate;
            PaymentOperation();
        }

        public Bank.Bank GetBank(int bankId)
        {
            return _banks.Find(x => x.Id == bankId);
        }

        private void PaymentOperation()
        {
            foreach (Bank.Bank bank in _banks)
            {
                bank.PaymentOperation(CurrentTime);
            }
        }
    }
}