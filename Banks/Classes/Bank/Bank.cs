using System;
using System.Collections.Generic;
using Banks.Classes.Account;
using Banks.Tools;

namespace Banks.Classes.Bank
{
    public class Bank
    {
        private static int _currentId = 1;
        private List<AccountTemplate> _accounts = new List<AccountTemplate>();
        private List<Client.Client> _clients = new List<Client.Client>();
        private DateTime _currentTime;

        public Bank(int operationLimit, PercentAmount depositInterestOnTheBalance, double debitInterestOnTheBalance, double commission, DateTime currentTime)
        {
            Id = _currentId++;
            OperationLimit = operationLimit;
            DepositInterestOnTheBalance = depositInterestOnTheBalance;
            DebitInterestOnTheBalance = debitInterestOnTheBalance;
            Commission = commission;
            _currentTime = currentTime;
        }

        public int Id { get; }
        public double DebitInterestOnTheBalance { get; }
        public double Commission { get; }
        public int OperationLimit { get; private set; }
        public PercentAmount DepositInterestOnTheBalance { get; }
        public IReadOnlyList<AccountTemplate> Accounts => _accounts;

        public AccountTemplate AddDebitAccount(Client.Client client, double startMoney)
        {
            var debitAccount = new DebitAccount(startMoney, _currentTime, DebitInterestOnTheBalance, client.Verification);
            client.AddAccount(debitAccount);
            return debitAccount;
        }

        public AccountTemplate AddDepositAccount(Client.Client client, double startMoney)
        {
            var depositAccount = new DepositAccount(startMoney, _currentTime, DepositInterestOnTheBalance.GetCurrentPercent(startMoney), client.Verification);
            client.AddAccount(depositAccount);
            return depositAccount;
        }

        public AccountTemplate AddCreditAccount(Client.Client client, double startMoney)
        {
            var creditAccount = new CreditAccount(startMoney, _currentTime, Commission, client.Verification);
            client.AddAccount(creditAccount);
            return creditAccount;
        }

        public void ChangeOperationLimit(int value)
        {
            if (value < 10000)
                throw new BankException("Operation limit should be at least 10000");
            OperationLimit = value;
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
    }
}