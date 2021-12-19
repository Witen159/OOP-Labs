namespace Banks.Classes.Account
{
    public class DebitAccount : AccountDecorator
    {
        public DebitAccount(Account account, double interestOnTheBalance)
            : base(account)
        {
            InterestOnTheBalance = interestOnTheBalance;
        }

        public double InterestOnTheBalance { get; }

        public override void Refill(double value)
        {
        }

        public override void Withdrawal(double value)
        {
        }

        public override void Transfer(AbstractAccount account, double value)
        {
        }
    }
}