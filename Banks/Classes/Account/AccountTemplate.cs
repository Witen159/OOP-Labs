namespace Banks.Classes.Account
{
    public abstract class AccountTemplate
    {
        private static int _currentId = 1;

        public AccountTemplate(double startMoney)
        {
            Id = _currentId++;
            Money = startMoney;
        }

        public double Money { get; }
        public int Id { get; }

        public virtual void Refill(double value)
        {
        }

        public virtual void Withdrawal(double value)
        {
        }
    }
}