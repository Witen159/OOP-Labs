using System;
using Banks.Tools;

namespace Banks.Classes.Account
{
    public class DebitAccount : AccountTemplate
    {
        private double _deductions = 0;
        public DebitAccount(double startMoney, DateTime currentTime, double interestOnTheBalance, bool verification)
            : base(startMoney, currentTime, verification)
        {
            InterestOnTheBalance = interestOnTheBalance;
        }

        public double InterestOnTheBalance { get; set; }

        public override void ReduceMoney(double amountOfMoney)
        {
            if (amountOfMoney > Money)
                throw new BankException("Debit account cannot go into negative territory");
            base.ReduceMoney(amountOfMoney);
        }

        public override void PaymentOperation(DateTime timeOfTheNewPayment)
        {
            var daysControlSystem = new DaysControlSystem();
            int differenceInDays = (timeOfTheNewPayment - CurrentTime).Days;
            for (int days = 0; days < differenceInDays; days++)
            {
                _deductions += Money * ((InterestOnTheBalance * 0.01) / daysControlSystem.DaysPerYear(CurrentTime));
                if (daysControlSystem.IsItLastDayOfMonth(CurrentTime))
                {
                    IncreaseMoney(_deductions);
                    _deductions = 0;
                }

                CurrentTime = CurrentTime.AddDays(1);
            }
        }
    }
}