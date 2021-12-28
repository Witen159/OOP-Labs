using System;
using Banks.Classes;
using Banks.Console_application.Bank_Manager;
using Banks.Console_application.Client_Manager;

namespace Banks.Console_application
{
    public class ConsoleApp
    {
        private CentralBank _centralBank = CentralBank.GetInstance(DateTime.Now);
        private ClientManager _clientManager = new ClientManager();
        private CentralBankManager _centralBankManager = new CentralBankManager();
        public ConsoleApp()
        {
            Console.WriteLine("Please use command numbers is our application");
            Console.WriteLine();

            StartMenu();
        }

        public void StartMenu()
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
                    _centralBankManager.BankManager();
                    break;
                case 2:
                    _clientManager.LogIn();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Wrong command");
                    break;
            }

            StartMenu();
        }
    }
}