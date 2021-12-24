using System;

namespace Banks.Classes.Account
{
    public class CreditAccount : AccountTemplate
    {
        public CreditAccount(double startMoney, DateTime currentTime, double commission, bool verification)
            : base(startMoney, currentTime, verification)
        {
            Commission = commission;
        }

        public double Commission { get; set; }
        public override void Refill(double value)
        {
        }

        public override void Withdrawal(double value)
        {
        }

        public override void PaymentOperation(DateTime timeOfTheNewPayment)
        {
            int differenceInDays = (timeOfTheNewPayment - CurrentTime).Days;
            for (int i = 0; i < differenceInDays; i++)
            {
                CurrentTime.AddDays(1);
                if (Money < 0)
                    ReduceMoney(Commission);
            }
        }
    }
}