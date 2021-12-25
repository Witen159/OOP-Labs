using System;
using Banks.Tools;

namespace Banks.Classes.Account
{
    public class CreditAccount : AccountTemplate
    {
        public CreditAccount(double startMoney, DateTime currentTime, double commission, int creditNegativeLimit, bool verification)
            : base(startMoney, currentTime, verification)
        {
            Commission = commission;
            CreditNegativeLimit = creditNegativeLimit;
        }

        public double Commission { get; set; }
        public int CreditNegativeLimit { get; set; }

        public override void ReduceMoney(double amountOfMoney)
        {
            IsWillGoOverCreditLimit(amountOfMoney);
            Money -= amountOfMoney;
        }

        public override void PaymentOperation(DateTime timeOfTheNewPayment)
        {
            int differenceInDays = (timeOfTheNewPayment - CurrentTime).Days;
            for (int days = 0; days < differenceInDays; days++)
            {
                if (Money < 0)
                {
                    IsWillGoOverCreditLimit(Commission);
                    ReduceMoney(Commission);
                }

                CurrentTime.AddDays(1);
            }
        }

        private void IsWillGoOverCreditLimit(double amountOfMoney)
        {
            if (Money - amountOfMoney < -CreditNegativeLimit)
                throw new BankException("The balance fell below the credit limit");
        }
    }
}