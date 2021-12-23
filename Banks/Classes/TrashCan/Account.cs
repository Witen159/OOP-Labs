namespace Banks.Classes.Account
{
    public class Account : AbstractAccount
    {
        private static int _currentId = 1;

        public Account(double startMoney)
        {
            Id = _currentId++;
            Money = startMoney;
        }

        public double Money { get; }
        public int Id { get; }

        public override void Refill(double value)
        {
        }

        public override void Withdrawal(double value)
        {
        }
    }
}