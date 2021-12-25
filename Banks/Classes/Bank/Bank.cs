using System;
using System.Collections.Generic;
using System.Linq;
using Banks.Classes.Account;
using Banks.Classes.Observer;
using Banks.Classes.Observer.Notification;
using Banks.Classes.Transaction;
using Banks.Tools;

namespace Banks.Classes.Bank
{
    public class Bank : IObservable
    {
        private static int _currentId = 1;
        private List<AccountTemplate> _accounts = new List<AccountTemplate>();
        private List<Client.Client> _clients = new List<Client.Client>();
        private List<IObserver> _observers = new List<IObserver>();
        private DateTime _currentTime;

        public Bank(string name, int operationLimit, int creditNegativeLimit, PercentAmount depositInterestOnTheBalance, double debitInterestOnTheBalance, double commission, DateTime currentTime)
        {
            Name = name;
            Id = _currentId++;
            ChangeOperationLimit(operationLimit);
            ChangeCreditNegativeLimit(creditNegativeLimit);
            ChangeDepositInterestOnTheBalance(depositInterestOnTheBalance);
            ChangeDebitInterestOnTheBalance(debitInterestOnTheBalance);
            ChangeCommission(commission);
            _currentTime = currentTime;
        }

        public int Id { get; }
        public string Name { get; }
        public double DebitInterestOnTheBalance { get; private set; }
        public double Commission { get; private set; }
        public int OperationLimit { get; private set; }
        public int CreditNegativeLimit { get; private set; }
        public PercentAmount DepositInterestOnTheBalance { get; private set; }
        public IReadOnlyList<AccountTemplate> Accounts => _accounts;

        public AccountTemplate AddDebitAccount(Client.Client client, double startMoney)
        {
            ClientRegisterCheck(client);
            var debitAccount = new DebitAccount(startMoney, _currentTime, DebitInterestOnTheBalance, client.Verification);
            client.AddAccount(debitAccount);
            _accounts.Add(debitAccount);
            return debitAccount;
        }

        public AccountTemplate AddDepositAccount(Client.Client client, double startMoney, DateTime depositCloseTime)
        {
            ClientRegisterCheck(client);
            var depositAccount = new DepositAccount(startMoney, _currentTime, DepositInterestOnTheBalance.GetCurrentPercent(startMoney), depositCloseTime, client.Verification);
            client.AddAccount(depositAccount);
            _accounts.Add(depositAccount);
            return depositAccount;
        }

        public AccountTemplate AddCreditAccount(Client.Client client, double startMoney)
        {
            ClientRegisterCheck(client);
            var creditAccount = new CreditAccount(startMoney, _currentTime, Commission, CreditNegativeLimit, client.Verification);
            client.AddAccount(creditAccount);
            _accounts.Add(creditAccount);
            return creditAccount;
        }

        public AbstractTransaction Transfer(AccountTemplate sender, AccountTemplate recipient, double amountOfMoney)
        {
            AccountCheck(sender);
            OperationLimitCheck(sender, amountOfMoney);
            return new TransferTransaction(sender, recipient, amountOfMoney, _currentTime);
        }

        public AbstractTransaction Refill(AccountTemplate account, double amountOfMoney)
        {
            AccountCheck(account);
            return new RefillTransaction(null, account, amountOfMoney, _currentTime);
        }

        public AbstractTransaction Withdrawal(AccountTemplate account, double amountOfMoney)
        {
            AccountCheck(account);
            OperationLimitCheck(account, amountOfMoney);
            return new WithdrawalTransaction(account, null, amountOfMoney, _currentTime);
        }

        public AbstractTransaction CancelOperation(AbstractTransaction transaction)
        {
            return new CancelTransaction(transaction);
        }

        public void ChangeOperationLimit(int value)
        {
            if (value < 10000)
                throw new BankException("Operation limit should be at least 10000");
            OperationLimit = value;

            NotifyObservers(new OperationLimitNotification());
        }

        public void ChangeCreditNegativeLimit(int value)
        {
            if (value < 10000)
                throw new BankException("Credit Negative Limit should be at least 10000");
            CreditNegativeLimit = value;
            foreach (CreditAccount account in _accounts.OfType<CreditAccount>())
            {
                account.CreditNegativeLimit = value;
            }

            NotifyObservers(new CreditLimitNotification());
        }

        public void ChangeCommission(double value)
        {
            if (value < 1000)
                throw new BankException("Commission should be at least 10000");
            Commission = value;
            foreach (CreditAccount account in _accounts.OfType<CreditAccount>())
            {
                account.Commission = value;
            }

            NotifyObservers(new CommissionNotification());
        }

        public void ChangeDebitInterestOnTheBalance(double value)
        {
            if (value <= 0 || value >= 100)
            {
                throw new BankException("Percents must be greater than 0 and less than 100");
            }

            DebitInterestOnTheBalance = value;
            foreach (DebitAccount account in _accounts.OfType<DebitAccount>())
            {
                account.InterestOnTheBalance = value;
            }

            NotifyObservers(new PercentNotification());
        }

        public void ChangeDepositInterestOnTheBalance(PercentAmount newPercentAmount)
        {
            DepositInterestOnTheBalance = newPercentAmount;
        }

        public void RegisterNewClient(Client.Client client)
        {
            _clients.Add(client);
        }

        public AccountTemplate GetAccount(int accountId)
        {
            return _accounts.Find(x => x.Id == accountId);
        }

        public void PaymentOperation(DateTime timeOfTheNewPayment)
        {
            _currentTime = timeOfTheNewPayment;
            foreach (AccountTemplate account in _accounts)
            {
                account.PaymentOperation(_currentTime);
            }
        }

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(INotification notification)
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update(notification);
            }
        }

        private void OperationLimitCheck(AccountTemplate account, double amountOfMoney)
        {
            if (!account.Verification && amountOfMoney > OperationLimit)
                throw new BankException($"Unconfirmed accounts are prohibited from operations above {OperationLimit}");
        }

        private void ClientRegisterCheck(Client.Client client)
        {
            if (!_clients.Contains(client))
                throw new BankException("Client should be registered in the bank");
        }

        private void AccountCheck(AccountTemplate account)
        {
            if (!_accounts.Contains(account))
                throw new BankException("The account does not belong to this bank");
        }
    }
}