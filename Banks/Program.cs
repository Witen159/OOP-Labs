using System;
using System.Collections.Generic;
using System.Linq;
using Banks.Classes;
using Banks.Classes.Account;
using Banks.Classes.Bank;
using Banks.Classes.Client;
using Banks.Classes.Transaction;

namespace Banks
{
    internal static class Program
    {
        private static void Main()
        {
            var clientsList = new List<Client>();
            Client currentClient = null;
            DateTime startTime = DateTime.Now;
            var centralBank = CentralBank.GetInstance(startTime);
            var cancelRequests = new List<AbstractTransaction>();
            var clientDirector = new ClientDirector();
            var clientBuilder = new ClientBuilder();
            clientDirector.Builder = clientBuilder;

            Console.WriteLine("Please use command numbers is our application");
            Console.WriteLine();

            void StartMenu()
            {
                Console.WriteLine("Choose who you are:");
                Console.WriteLine("1. Bank manager");
                Console.WriteLine("2. Client");
                Console.WriteLine("3. Exit Menu");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        CentralBankManager();
                        break;
                    case 2:
                        LogIn();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Wrong command");
                        StartMenu();
                        return;
                }

                return;
            }

            void CentralBankManager()
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Register new bank");
                Console.WriteLine("2. Banks list");
                Console.WriteLine("3. Transaction cancellation requests");
                Console.WriteLine("4. Cancel transaction");
                Console.WriteLine("5. Return to start menu");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        CreateBank();

                        CentralBankManager();
                        return;
                    case 2:
                        foreach (Bank bank in centralBank.Banks)
                        {
                            Console.WriteLine($"{bank.Name} id: {bank.Id}");
                        }

                        Console.WriteLine();
                        CentralBankManager();
                        return;
                    case 3:
                        Console.WriteLine("Id of transactions with cancellation request");
                        foreach (AbstractTransaction transactions in cancelRequests)
                        {
                            Console.WriteLine($"{transactions.Id}");
                        }

                        Console.WriteLine();
                        CentralBankManager();
                        return;
                    case 4:
                        Console.WriteLine("Enter Id of transaction to cancel");
                        int id = Convert.ToInt32(Console.ReadLine());
                        foreach (AbstractTransaction transaction in cancelRequests)
                        {
                            if (transaction.Id == id)
                            {
                                centralBank.CancelOperation(transaction);
                                break;
                            }
                        }

                        Console.WriteLine();
                        CentralBankManager();
                        return;
                    case 5:
                        StartMenu();
                        return;
                    default:
                        Console.WriteLine("Wrong command");
                        CentralBankManager();
                        return;
                }
            }

            void LogIn()
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
                        currentClient = null;

                        foreach (Client client in clientsList)
                        {
                            if (client.Name + " " + client.Surname == fullname)
                            {
                                currentClient = client;
                            }
                        }

                        if (currentClient == null)
                        {
                            Console.WriteLine("Such a user is not registered");
                            Console.WriteLine();
                            LogIn();
                            return;
                        }

                        ClientManager();
                        break;
                    case 2:
                        Registration();

                        ClientManager();
                        break;
                    case 3:
                        StartMenu();
                        return;
                    default:
                        Console.WriteLine("Wrong command");
                        LogIn();
                        return;
                }
            }

            void ClientManager()
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
                Console.WriteLine("9. Wait some time");
                Console.WriteLine("10. Return to start menu");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        foreach (Bank bank in centralBank.Banks)
                        {
                            Console.Write($"{bank.Name} id: {bank.Id} ");
                            if (bank.Clients.Contains(currentClient))
                                Console.Write("(You registered)");
                            Console.WriteLine();
                        }

                        ClientManager();
                        return;
                    case 2:
                        Console.WriteLine("Enter id of bank you want to register");
                        int bankId = Convert.ToInt32(Console.ReadLine());
                        foreach (Bank bank in centralBank.Banks)
                        {
                            if (bank.Id == bankId)
                                bank.RegisterNewClient(currentClient);
                            break;
                        }

                        ClientManager();
                        return;
                    case 3:
                        CreateAccount();

                        ClientManager();
                        return;
                    case 4:
                        Console.WriteLine("Your accounts id:");
                        foreach (AccountTemplate account in currentClient.Accounts)
                        {
                            Console.WriteLine($"{account.Id}");
                        }

                        ClientManager();
                        return;
                    case 5:
                        Console.WriteLine("Enter id of account");
                        int balanceAccountId = Convert.ToInt32(Console.ReadLine());
                        foreach (AccountTemplate account in currentClient.Accounts)
                        {
                            if (account.Id == balanceAccountId)
                                Console.WriteLine($"Balance: {account.Money}");
                            break;
                        }

                        ClientManager();
                        return;
                    case 6:
                        Console.WriteLine("Enter id of your account");
                        int accountOperationId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Transaction amount");
                        int transactionAmount = Convert.ToInt32(Console.ReadLine());
                        AccountOperation(accountOperationId, transactionAmount);

                        ClientManager();
                        return;
                    case 7:
                        foreach (AccountTemplate account in currentClient.Accounts)
                        {
                            Console.WriteLine($"Account {account.Id} transactions id:");

                            foreach (AbstractTransaction transaction in account.TransactionHistory)
                            {
                                Console.WriteLine($"\t{transaction.Id}");
                            }
                        }

                        ClientManager();
                        return;
                    case 8:
                        AbstractTransaction transactionToCancel = null;
                        Console.WriteLine("Enter id of account with transaction you want to cancel");
                        int accountId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter id of transaction");
                        int transactionId = Convert.ToInt32(Console.ReadLine());
                        foreach (AccountTemplate account in currentClient.Accounts)
                        {
                            if (account.Id == accountId)
                            {
                                foreach (AbstractTransaction transaction in account.TransactionHistory)
                                {
                                    if (transaction.Id == transactionId)
                                        transactionToCancel = transaction;
                                    break;
                                }
                            }
                        }

                        if (transactionToCancel == null)
                            Console.WriteLine("No such transaction");
                        else
                            cancelRequests.Add(transactionToCancel);

                        ClientManager();
                        return;
                    case 9:
                        Console.WriteLine("Enter the date you want to wait until (year, month, day)");
                        var newDate = new DateTime(
                            Convert.ToInt32(Console.ReadLine()),
                            Convert.ToInt32(Console.ReadLine()),
                            Convert.ToInt32(Console.ReadLine()));

                        if ((newDate - centralBank.CurrentTime).Days < 1)
                            Console.WriteLine("New date should be at least next day");
                        else
                            centralBank.NewDate(newDate);

                        ClientManager();
                        return;
                    case 10:
                        StartMenu();
                        return;
                    default:
                        Console.WriteLine("Wrong command");
                        ClientManager();
                        return;
                }
            }

            void CreateBank()
            {
                Console.WriteLine("Enter the parameters");
                Console.WriteLine("Bank name:");
                string bankName = Console.ReadLine();

                Console.WriteLine("Operations limit:");
                int operationsLimit = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Credit negative limit:");
                int creditLimit = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Commission:");
                double commission = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Debit interest on the balance:");
                double debitInterest = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine(
                    "Percent for deposit accounts (count, Money borders (count - 1 times), percents (count times)):");
                int count = Convert.ToInt32(Console.ReadLine());
                var moneyBorders = new List<int>();
                for (int i = 0; i < count - 1; i++)
                {
                    moneyBorders.Add(Convert.ToInt32(Console.ReadLine()));
                }

                var percents = new List<double>();
                for (int i = 0; i < count; i++)
                {
                    percents.Add(Convert.ToDouble(Console.ReadLine()));
                }

                var percentAmount = new PercentAmount(moneyBorders, percents);

                centralBank.RegisterNewBank(bankName, operationsLimit, creditLimit, percentAmount, debitInterest, commission);
            }

            void Registration()
            {
                Console.WriteLine("To have verified profile you need to add your address and passport");
                Console.WriteLine("Type your name:");
                string name = Console.ReadLine();
                Console.WriteLine("Type your surname:");
                string surname = Console.ReadLine();

                foreach (Client client in clientsList)
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
                    clientDirector.BuildDefaultClient(name, surname);
                else if (address == string.Empty)
                    clientDirector.BuildClientWithPassport(name, surname, Convert.ToInt32(passport));
                else if (passport == string.Empty)
                    clientDirector.BuildClientWithAddress(name, surname, address);
                else
                    clientDirector.BuildFullClient(name, surname, Convert.ToInt32(passport), address);

                currentClient = clientBuilder.GetClient();
                clientsList.Add(currentClient);
            }

            void CreateAccount()
            {
                Console.WriteLine("Enter id of bank you want to create account");
                int bankId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                Bank bankToAdd = null;
                foreach (Bank bank in centralBank.Banks)
                {
                    if (bank.Id == bankId)
                        bankToAdd = bank;
                    break;
                }

                if (bankToAdd == null)
                {
                    Console.WriteLine("No such bank");
                    ClientManager();
                    return;
                }

                Console.WriteLine("Enter what type of account you want to create");
                Console.WriteLine("1. Debit");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Credit");
                Console.WriteLine("4. Cancel");
                int accountType = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter start amount of money");
                int startAmountOfMoney = Convert.ToInt32(Console.ReadLine());

                switch (accountType)
                {
                    case 1:
                        bankToAdd.AddDebitAccount(currentClient, startAmountOfMoney);
                        break;
                    case 2:
                        Console.WriteLine("Enter the account closing date (year, month, day)");
                        var closeDate = new DateTime(
                            Convert.ToInt32(Console.ReadLine()),
                            Convert.ToInt32(Console.ReadLine()),
                            Convert.ToInt32(Console.ReadLine()));
                        bankToAdd.AddDepositAccount(currentClient, startAmountOfMoney, closeDate);
                        break;
                    case 3:
                        bankToAdd.AddCreditAccount(currentClient, startAmountOfMoney);
                        break;
                    case 4:
                        ClientManager();
                        return;
                }
            }

            void AccountOperation(int accountId, int transactionAmount)
            {
                AccountTemplate operationAccount = currentClient.Accounts.First(x => x.Id == accountId);
                Bank operationBank = centralBank.Banks.First(x => x.Accounts.Contains(operationAccount));

                Console.WriteLine("Select an operation");
                Console.WriteLine("1. Refill");
                Console.WriteLine("2. Withdrawal");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("Cancel");
                int operation = Convert.ToInt32(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        operationBank.Refill(operationAccount, transactionAmount);
                        break;
                    case 2:
                        operationBank.Withdrawal(operationAccount, transactionAmount);
                        break;
                    case 3:
                        Console.WriteLine("Enter id of account you want to transfer to");
                        int newAccountId = Convert.ToInt32(Console.ReadLine());
                        operationBank.Transfer(operationAccount, FindAccountFromId(newAccountId), transactionAmount);
                        break;
                    case 4:
                        ClientManager();
                        return;
                }
            }

            AccountTemplate FindAccountFromId(int accountId)
            {
                foreach (Bank bank in centralBank.Banks)
                {
                    foreach (AccountTemplate account in bank.Accounts)
                    {
                        if (account.Id == accountId)
                            return account;
                    }
                }

                return null;
            }

            StartMenu();
        }
    }
}
