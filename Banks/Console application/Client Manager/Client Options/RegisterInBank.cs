using System;
using Banks.Classes;
using Banks.Classes.Bank;
using Banks.Classes.Client;

namespace Banks.Console_application.Client_Manager.Client_Options
{
    public class RegisterInBank : IClientOption
    {
        public void Option(Client currentClient)
        {
            var centralBank = CentralBank.GetInstance(DateTime.Now);
            Console.WriteLine("Enter id of bank you want to register");
            int bankId = Convert.ToInt32(Console.ReadLine());
            foreach (Bank bank in centralBank.Banks)
            {
                if (bank.Id == bankId)
                    bank.RegisterNewClient(currentClient);
                break;
            }
        }
    }
}