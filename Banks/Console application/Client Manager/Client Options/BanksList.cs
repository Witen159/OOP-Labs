using System;
using System.Linq;
using Banks.Classes;
using Banks.Classes.Bank;
using Banks.Classes.Client;

namespace Banks.Console_application.Client_Manager.Client_Options
{
    public class BanksList : IClientOption
    {
        public void Option(Client currentClient)
        {
            var centralBank = CentralBank.GetInstance(DateTime.Now);
            foreach (Bank bank in centralBank.Banks)
            {
                Console.Write($"{bank.Name} id: {bank.Id} ");
                if (bank.Clients.Contains(currentClient))
                    Console.Write("(You registered)");
                Console.WriteLine();
            }
        }
    }
}