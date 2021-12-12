namespace Banks.Classes.Account
{
    public abstract class Account
    {
        private static int _currentId = 1;

        public Account()
        {
            Id = _currentId;
            _currentId++;
        }

        public int Money { get; private set; }
        public int Id { get; }
        public double InterestOnTheBalance { get; }

        public virtual void Refill(int value)
        {
        }

        public void Withdrawal(int value)
        {
        }
    }
}