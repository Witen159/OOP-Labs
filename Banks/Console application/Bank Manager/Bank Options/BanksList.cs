using System;
using Banks.Classes;
using Banks.Classes.Bank;

namespace Banks.Console_application.Bank_Manager.Bank_Options
{
    public class BanksList : IBankOption
    {
        public void Option()
        {
            var centralBank = CentralBank.GetInstance(DateTime.Now);
            foreach (Bank bank in centralBank.Banks)
            {
                Console.WriteLine($"{bank.Name} id: {bank.Id}");
            }

            Console.WriteLine();
        }
    }
}