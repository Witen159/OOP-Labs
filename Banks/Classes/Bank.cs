using System.Collections.Generic;

namespace Banks.Classes
{
    public class Bank
    {
        private List<Client> _clients;

        public Bank()
        {
            _clients = new List<Client>();
        }

        public void RegisterNewClient(Client client)
        {
            _clients.Add(client);
        }
    }
}