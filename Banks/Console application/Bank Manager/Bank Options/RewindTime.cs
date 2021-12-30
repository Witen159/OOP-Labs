using System;
using Banks.Classes;

namespace Banks.Console_application.Bank_Manager.Bank_Options
{
    public class RewindTime : IBankOption
    {
        public void Option()
        {
            var centralBank = CentralBank.GetInstance(DateTime.Now);
            Console.WriteLine("Enter the date you want to wait until (year, month, day)");
            var newDate = new DateTime(
                Convert.ToInt32(Console.ReadLine()),
                Convert.ToInt32(Console.ReadLine()),
                Convert.ToInt32(Console.ReadLine()));

            if ((newDate - centralBank.CurrentTime).Days < 1)
                Console.WriteLine("New date should be at least next day");
            else
                centralBank.NewDate(newDate);
        }
    }
}