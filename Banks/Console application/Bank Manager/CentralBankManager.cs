using System;
using Banks.Classes.Bank;
using Banks.Classes.Transaction;
using Banks.Console_application.Bank_Manager.Bank_Options;

namespace Banks.Console_application.Bank_Manager
{
    public class CentralBankManager
    {
        private IBankOption _bankOption = null;
        public void BankManager()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Register new bank");
            Console.WriteLine("2. Banks list");
            Console.WriteLine("3. Rewind time");
            Console.WriteLine("4. Return to start menu");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    _bankOption = new RegisterNewBank();
                    break;
                case 2:
                    _bankOption = new BanksList();
                    break;
                case 3:
                    _bankOption = new RewindTime();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Wrong command");
                    BankManager();
                    return;
            }

            _bankOption.Option();
            BankManager();
        }
    }
}