using System;
using Banks.Classes;
using Banks.Classes.Bank;
using Banks.Classes.Client;

namespace Banks.Console_application.Client_Manager.Client_Options
{
    public class CreateAccount : IClientOption
    {
        public void Option(Client currentClient)
        {
            var centralBank = CentralBank.GetInstance(DateTime.Now);
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
                    return;
            }
        }
    }
}