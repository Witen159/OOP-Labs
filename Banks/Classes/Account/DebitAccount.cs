namespace Banks.Classes.Account
{
    public class DebitAccount : AccountTemplate
    {
        public DebitAccount(double startMoney, double interestOnTheBalance)
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