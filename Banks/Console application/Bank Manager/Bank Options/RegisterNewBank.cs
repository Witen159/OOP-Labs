using System;
using System.Collections.Generic;
using Banks.Classes;
using Banks.Classes.Bank;

namespace Banks.Console_application.Bank_Manager.Bank_Options
{
    public class RegisterNewBank : IBankOption
    {
        public void Option()
        {
            var centralBank = CentralBank.GetInstance(DateTime.Now);
            Console.WriteLine("Enter the parameters");
            Console.WriteLine("Bank name:");
            string bankName = Console.ReadLine();

            Console.WriteLine("Operations limit:");
            int operationsLimit = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Credit negative limit:");
            int creditLimit = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Commission:");
            double commission = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Debit interest on the balance:");
            double debitInterest = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine(
                "Percent for deposit accounts (count, Money borders (count - 1 times), percents (count times)):");
            int count = Convert.ToInt32(Console.ReadLine());
            var moneyBorders = new List<int>();
            for (int i = 0; i < count - 1; i++)
            {
                moneyBorders.Add(Convert.ToInt32(Console.ReadLine()));
            }

            var percents = new List<double>();
            for (int i = 0; i < count; i++)
            {
                percents.Add(Convert.ToDouble(Console.ReadLine()));
            }

            var percentAmount = new PercentAmount(moneyBorders, percents);

            centralBank.RegisterNewBank(bankName, operationsLimit, creditLimit, percentAmount, debitInterest, commission);
        }
    }
}