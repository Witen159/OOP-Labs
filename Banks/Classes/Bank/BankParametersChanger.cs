using System.Linq;
using Banks.Classes.Account;
using Banks.Classes.Observer.Notification;
using Banks.Tools;

namespace Banks.Classes.Bank
{
    public class BankParametersChanger
    {
        private const int MinimumOperationLimit = 10000;
        private const int MinimumCreditLimit = 10000;
        private const int MinimumCommission = 1000;
        private Bank _bank;

        public BankParametersChanger(Bank bank)
        {
            _bank = bank;
        }

        public void ChangeOperationLimit(int value)
        {
            if (value < MinimumOperationLimit)
                throw new BankException("Operation limit should be at least 10000");
            _bank.OperationLimit = value;

            _bank.NotifyObservers(new OperationLimitNotification());
        }

        public void ChangeCreditNegativeLimit(int value)
        {
            if (value < MinimumCreditLimit)
                throw new BankException("Credit Negative Limit should be at least 10000");
            _bank.CreditNegativeLimit = value;
            foreach (CreditAccount account in _bank.Accounts.OfType<CreditAccount>())
            {
                account.CreditNegativeLimit = value;
            }

            _bank.NotifyObservers(new CreditLimitNotification());
        }

        public void ChangeCommission(double value)
        {
            if (value < MinimumCommission)
                throw new BankException("Commission should be at least 10000");
            _bank.Commission = value;
            foreach (CreditAccount account in _bank.Accounts.OfType<CreditAccount>())
            {
                account.Commission = value;
            }

            _bank.NotifyObservers(new CommissionNotification());
        }

        public void ChangeDebitInterestOnTheBalance(double value)
        {
            if (value <= 0 || value >= 100)
            {
                throw new BankException("Percents must be greater than 0 and less than 100");
            }

            _bank.DebitInterestOnTheBalance = value;
            foreach (DebitAccount account in _bank.Accounts.OfType<DebitAccount>())
            {
                account.InterestOnTheBalance = value;
            }

            _bank.NotifyObservers(new PercentNotification());
        }

        public void ChangeDepositInterestOnTheBalance(PercentAmount newPercentAmount)
        {
            _bank.DepositInterestOnTheBalance = newPercentAmount;
        }
    }
}