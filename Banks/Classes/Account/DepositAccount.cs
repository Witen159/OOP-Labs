using System;

namespace Banks.Classes.Account
{
    public class DepositAccount : AccountTemplate
    {
        public DepositAccount(double startMoney, DateTime currentTime, double interestOnTheBalance, bool verification)
            : base(startMoney, currentTime, verification)
        {
            InterestOnTheBalance = interestOnTheBalance;
        }

        public double InterestOnTheBalance { get; set; }

        public override void Refill(double value)
        {
        }

        public override void Withdrawal(double value)
        {
        }

        public override void PaymentOperation(DateTime timeOfTheNewPayment)
        {
        }
    }
}