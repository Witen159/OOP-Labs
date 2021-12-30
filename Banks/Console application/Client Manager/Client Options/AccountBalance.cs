using System;
using Banks.Classes.Account;
using Banks.Classes.Client;

namespace Banks.Console_application.Client_Manager.Client_Options
{
    public class AccountBalance : IClientOption
    {
        public void Option(Client currentClient)
        {
            Console.WriteLine("Enter id of account");
            int balanceAccountId = Convert.ToInt32(Console.ReadLine());
            foreach (AccountTemplate account in currentClient.Accounts)
            {
                if (account.Id == balanceAccountId)
                    Console.WriteLine($"Balance: {account.Money}");
                break;
            }
        }
    }
}