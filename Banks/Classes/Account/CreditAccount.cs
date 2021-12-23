namespace Banks.Classes.Account
{
    public class CreditAccount : AccountTemplate
    {
        public CreditAccount(double startMoney, double commission)
            : base(startMoney)
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
    }
}