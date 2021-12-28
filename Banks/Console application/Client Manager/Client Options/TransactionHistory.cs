using System;
using Banks.Classes.Account;
using Banks.Classes.Client;
using Banks.Classes.Transaction;

namespace Banks.Console_application.Client_Manager.Client_Options
{
    public class TransactionHistory : IClientOption
    {
        public void Option(Client currentClient)
        {
            foreach (AccountTemplate account in currentClient.Accounts)
            {
                Console.WriteLine($"Account {account.Id} transactions id:");

                foreach (AbstractTransaction transaction in account.TransactionHistory)
                {
                    Console.WriteLine($"\t{transaction.Id}");
                }
            }
        }
    }
}