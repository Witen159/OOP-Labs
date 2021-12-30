using System;
using Banks.Classes.Account;
using Banks.Classes.Client;

namespace Banks.Console_application.Client_Manager.Client_Options
{
    public class AccountsList : IClientOption
    {
        public void Option(Client currentClient)
        {
            Console.WriteLine("Your accounts id:");
            foreach (AccountTemplate account in currentClient.Accounts)
            {
                Console.WriteLine($"{account.Id}");
            }
        }
    }
}