using System;
using Banks.Classes;
using Banks.Classes.Account;
using Banks.Classes.Client;
using Banks.Classes.Transaction;

namespace Banks.Console_application.Client_Manager.Client_Options
{
    public class TransactionCancellation : IClientOption
    {
        public void Option(Client currentClient)
        {
            var centralBank = CentralBank.GetInstance(DateTime.Now);
            Console.WriteLine("Enter id of account and transaction you want to cancel");
            int accountId = Convert.ToInt32(Console.ReadLine());
            int transactionId = Convert.ToInt32(Console.ReadLine());

            foreach (AccountTemplate account in currentClient.Accounts)
            {
                if (account.Id == accountId)
                {
                    foreach (AbstractTransaction transaction in account.TransactionHistory)
                    {
                        if (transaction.Id == transactionId)
                            centralBank.CancelOperation(transaction);
                        return;
                    }
                }
            }
        }
    }
}