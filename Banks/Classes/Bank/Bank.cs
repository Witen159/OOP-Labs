using System.Collections.Generic;

namespace Banks.Classes.Bank
{
    public class Bank
    {
        private List<Account.Account> _accounts;

        public Bank()
        {
            _accounts = new List<Account.Account>();
        }

        // public void RegisterNewClient(Client.Client client)
        // {
        //     _clients.Add(client);
        // }
    }
}