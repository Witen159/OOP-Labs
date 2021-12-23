namespace Banks.Classes.Account
{
    public class DepositAccount : AccountTemplate
    {
        public DepositAccount(double startMoney, double interestOnTheBalance)
            : base(startMoney)
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
    }
}