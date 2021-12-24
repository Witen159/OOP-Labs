using System;
using System.Collections.Generic;
using Banks.Classes.Account;
using Banks.Classes.Bank;

namespace Banks.Classes
{
    public sealed class CentralBank
    {
        private static CentralBank _instance;
        private List<Bank.Bank> _banks = new List<Bank.Bank>();
        private DateTime _currentTime;

        private CentralBank()
        {
            _currentTime = DateTime.Now;
        }

        public static CentralBank GetInstance()
        {
            return _instance ??= new CentralBank();
        }

        public Bank.Bank RegisterNewBank(int operationLimit, PercentAmount depositInterestOnTheBalance, double debitInterestOnTheBalance, double commission)
        {
            var newBank = new Bank.Bank(operationLimit, depositInterestOnTheBalance, debitInterestOnTheBalance, commission, _currentTime);
            _banks.Add(newBank);
            return newBank;
        }

        public DateTime GetCurrentTime()
        {
            return _instance._currentTime;
        }

        public void AddTime(TimeSpan timespan)
        {
            _instance._currentTime += timespan;
            PaymentOperation();
        }

        public void Transfer(AccountTemplate fromAccount, AccountTemplate toAccount, double amountOfMoney)
        {
        }

        public Bank.Bank GetBank(int bankId)
        {
            return _banks.Find(x => x.Id == bankId);
        }

        private void PaymentOperation()
        {
            foreach (Bank.Bank bank in _banks)
            {
                bank.PaymentOperation(_currentTime);
            }
        }
    }
}