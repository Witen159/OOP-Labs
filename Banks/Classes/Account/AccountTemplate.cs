using System;

namespace Banks.Classes.Account
{
    public abstract class AccountTemplate
    {
        private static int _currentId = 1;

        public AccountTemplate(double startMoney, DateTime currentTime, bool verification)
        {
            Id = _currentId++;
            Money = startMoney;
            this.CurrentTime = currentTime;
            Verification = verification;
        }

        public double Money { get; private set; }
        public DateTime CurrentTime { get; protected set; }
        public int Id { get; }
        public bool Verification { get; private set; }

        public void Refill(double value)
        {
            IncreaseMoney(value);
        }

        public virtual void Withdrawal(double value)
        {
        }

        public void IncreaseMoney(double amountOfMoney)
        {
            Money += amountOfMoney;
        }

        public void ReduceMoney(double amountOfMoney)
        {
            Money -= amountOfMoney;
        }

        public virtual void PaymentOperation(DateTime timeOfTheNewPayment)
        {
        }

        // public void CancelOperation(double transactionAmount)
        // {
        //     Money += transactionAmount;
        // }
        public void СonfirmVerification()
        {
            Verification = true;
        }

        protected bool IsItLastDayOfMonth()
        {
            var firstDayOfMonth = new DateTime(CurrentTime.Year, CurrentTime.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            return CurrentTime == lastDayOfMonth;
        }

        protected int DaysPerYear()
        {
            return DateTime.IsLeapYear(CurrentTime.Year) ? 366 : 365;
        }
    }
}