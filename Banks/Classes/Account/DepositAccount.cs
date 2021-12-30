using System;
using Banks.Tools;

namespace Banks.Classes.Account
{
    public class DepositAccount : AccountTemplate
    {
        private double _deductions = 0;
        public DepositAccount(double startMoney, DateTime currentTime, double interestOnTheBalance, DateTime depositCloseTime, bool verification)
            : base(startMoney, currentTime, verification)
        {
            if ((depositCloseTime - currentTime).Days < 30)
                throw new BankException("Deposit account must be opened for at least 30 days");
            DepositCloseTime = depositCloseTime;
            InterestOnTheBalance = interestOnTheBalance;
            AccountIsOpen = true;
        }

        public double InterestOnTheBalance { get; set; }
        public DateTime DepositCloseTime { get; }
        public bool AccountIsOpen { get; private set; }

        public override void ReduceMoney(double amountOfMoney)
        {
            if (AccountIsOpen)
                throw new BankException("You cannot withdraw money from the account until it is close");
            if (amountOfMoney > Money)
                throw new BankException("Deposit account cannot go into negative territory");
            base.ReduceMoney(amountOfMoney);
        }

        public override void PaymentOperation(DateTime timeOfTheNewPayment)
        {
            var daysControlSystem = new DaysControlSystem();
            int differenceInDays = (timeOfTheNewPayment - CurrentTime).Days;
            for (int days = 0; days < differenceInDays; days++)
            {
                if (AccountIsOpen)
                {
                    _deductions += Money * ((InterestOnTheBalance * 0.01) / daysControlSystem.DaysPerYear(CurrentTime));

                    if (daysControlSystem.IsItLastDayOfMonth(CurrentTime))
                    {
                        IncreaseMoney(_deductions);
                        _deductions = 0;
                    }

                    if (CurrentTime.Date == DepositCloseTime.Date)
                    {
                        IncreaseMoney(_deductions);
                        _deductions = 0;
                        AccountIsOpen = false;
                    }
                }

                CurrentTime = CurrentTime.AddDays(1);
            }
        }
    }
}