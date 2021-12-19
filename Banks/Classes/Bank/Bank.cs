using System.Collections.Generic;
using Banks.Classes.Account;
using Banks.Tools;

namespace Banks.Classes.Bank
{
    public class Bank
    {
        private static int _currentId = 1;
        private List<AccountDecorator> _accounts;
        private int _operationLimit;

        public Bank(int operationLimit)
        {
            _accounts = new List<AccountDecorator>();
            Id = _currentId++;
            _operationLimit = operationLimit;
        }

        public int Id { get; }
        public IReadOnlyList<AccountDecorator> Accounts => _accounts;
        public void CancelTransaction()
        {
        }

        public void ChangeOperationLimit(int value)
        {
            if (value < 10000)
                throw new BankException("Operation limit should be at least 10000");
            _operationLimit = value;
        }

        // public void RegisterNewClient(Client.Client client)
        // {
        //     _clients.Add(client);
        // }
    }
}