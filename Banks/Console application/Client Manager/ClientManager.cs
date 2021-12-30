using System;
using System.Collections.Generic;
using System.Linq;
using Banks.Classes;
using Banks.Classes.Account;
using Banks.Classes.Bank;
using Banks.Classes.Client;
using Banks.Classes.Transaction;
using Banks.Console_application.Client_Manager.Client_Options;

namespace Banks.Console_application.Client_Manager
{
    public class ClientManager
    {
        private List<Client> _clientsList = new List<Client>();
        private Client _currentClient = null;
        private ClientDirector _clientDirector = new ClientDirector();
        private ClientBuilder _clientBuilder = new ClientBuilder();
        private IClientOption _clientOption = null;

        public ClientManager()
        {
            _clientDirector.Builder = _clientBuilder;
        }

        public void LogIn()
        {
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Register in system");
            Console.WriteLine("3. Return to start menu");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Type your full name:");
                    string fullname = Console.ReadLine();
                    Console.WriteLine();
                    _currentClient = null;

                    foreach (Client client in _clientsList)
                    {
                        if (client.Name + " " + client.Surname == fullname)
                        {
                            _currentClient = client;
                            break;
                        }
                    }

                    if (_currentClient == null)
                    {
                        Console.WriteLine("Such a user is not registered");
                        Console.WriteLine();
                        LogIn();
                        return;
                    }

                    Manager();
                    return;
                case 2:
                    Registration();

                    Manager();
                    return;
                case 3:
                    return;
                default:
                    Console.WriteLine("Wrong command");
                    LogIn();
                    return;
            }
        }

        private void Manager()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Banks List");
            Console.WriteLine("2. Register in bank");
            Console.WriteLine("3. Create new account");
            Console.WriteLine("4. Accounts list");
            Console.WriteLine("5. Account balance");
            Console.WriteLine("6. Account operations");
            Console.WriteLine("7. Transaction history");
            Console.WriteLine("8. Request to cancel a transaction");
            Console.WriteLine("9. Return to start menu");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    _clientOption = new BanksList();
                    break;
                case 2:
                    _clientOption = new RegisterInBank();
                    break;
                case 3:
                    _clientOption = new CreateAccount();
                    break;
                case 4:
                    _clientOption = new AccountsList();
                    break;
                case 5:
                    _clientOption = new AccountBalance();
                    break;
                case 6:
                    _clientOption = new AccountOperations();
                    break;
                case 7:
                    _clientOption = new TransactionHistory();
                    break;
                case 8:
                    _clientOption = new TransactionCancellation();
                    break;
                case 9:
                    return;
                default:
                    Console.WriteLine("Wrong command");
                    Manager();
                    return;
            }

            _clientOption.Option(_currentClient);
            Manager();
        }

        private void Registration()
        {
            Console.WriteLine("To have verified profile you need to add your address and passport");
            Console.WriteLine("Type your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Type your surname:");
            string surname = Console.ReadLine();

            foreach (Client client in _clientsList)
            {
                if (name == client.Name && surname == client.Surname)
                {
                    Console.WriteLine("This user is already registered");
                    LogIn();
                    return;
                }
            }

            Console.WriteLine("Type your address or tap Enter");
            string address = Console.ReadLine();

            Console.WriteLine("Type your passport number or tap Enter");
            string passport = Console.ReadLine();

            if (address == string.Empty && passport == string.Empty)
                _clientDirector.BuildDefaultClient(name, surname);
            else if (address == string.Empty)
                _clientDirector.BuildClientWithPassport(name, surname, Convert.ToInt32(passport));
            else if (passport == string.Empty)
                _clientDirector.BuildClientWithAddress(name, surname, address);
            else
                _clientDirector.BuildFullClient(name, surname, Convert.ToInt32(passport), address);

            _currentClient = _clientBuilder.GetClient();
            _clientsList.Add(_currentClient);
        }
    }
}