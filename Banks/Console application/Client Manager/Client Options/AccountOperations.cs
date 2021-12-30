using System;
using System.Linq;
using Banks.Classes;
using Banks.Classes.Account;
using Banks.Classes.Bank;
using Banks.Classes.Client;

namespace Banks.Console_application.Client_Manager.Client_Options
{
    public class AccountOperations : IClientOption
    {
        public void Option(Client currentClient)
        {
            var centralBank = CentralBank.GetInstance(DateTime.Now);
            Console.WriteLine("Enter id of your account");
            int accountOperationId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Transaction amount");
            int transactionAmount = Convert.ToInt32(Console.ReadLine());

            AccountTemplate operationAccount = currentClient.Accounts.First(x => x.Id == accountOperationId);
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
                    return;
            }
        }

        private AccountTemplate FindAccountFromId(int accountId)
        {
            var centralBank = CentralBank.GetInstance(DateTime.Now);
            return centralBank.Banks.SelectMany(bank => bank.Accounts).FirstOrDefault(account => account.Id == accountId);
        }
    }
}