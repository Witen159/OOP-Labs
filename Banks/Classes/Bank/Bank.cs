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
        private int _operationLimit;

        public Bank(int operationLimit, PercentAmount percentAmount)
        {
            Id = _currentId++;
            _operationLimit = operationLimit;
            DepositInterestOnTheBalance = percentAmount;
        }

        public int Id { get; }
        public double DebitInterestOnTheBalance { get; }
        public double Commission { get; }
        public PercentAmount DepositInterestOnTheBalance { get; }
        public IReadOnlyList<AccountTemplate> Accounts => _accounts;

        public AccountTemplate AddDebitAccount(Client.Client client, double startMoney)
        {
        }

        public AccountTemplate AddDepositAccount(Client.Client client, double startMoney)
        {
        }

        public AccountTemplate AddCreditAccount(Client.Client client, double startMoney)
        {
        }

        public void ChangeOperationLimit(int value)
        {
            if (value < 10000)
                throw new BankException("Operation limit should be at least 10000");
            _operationLimit = value;
        }

        public void RegisterNewClient(Client.Client client)
        {
            _clients.Add(client);
        }
    }
}