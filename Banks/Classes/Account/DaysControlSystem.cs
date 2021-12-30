using System;

namespace Banks.Classes.Account
{
    public class DaysControlSystem
    {
        public bool IsItLastDayOfMonth(DateTime currentTime)
        {
            var firstDayOfMonth = new DateTime(currentTime.Year, currentTime.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            return currentTime.Date == lastDayOfMonth.Date;
        }

        public int DaysPerYear(DateTime currentTime)
        {
            return DateTime.IsLeapYear(currentTime.Year) ? 366 : 365;
        }
    }
}