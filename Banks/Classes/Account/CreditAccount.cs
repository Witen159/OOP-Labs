namespace Banks.Classes.Account
{
    public class CreditAccount : AccountDecorator
    {
        public CreditAccount(Account account)
            : base(account)
        {
        }

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