using System;
using Banks.Classes.Account;

namespace Banks.Classes.Transaction
{
    public abstract class AbstractTransaction
    {
        private static int _currentId = 1;

        public AbstractTransaction(AccountTemplate sender, AccountTemplate recipient, double amountOfMoney, DateTime currentTime)
        {
            Id = _currentId++;
            Sender = sender;
            Recipient = recipient;
            AmountOfMoney = amountOfMoney;
            TransactionTime = currentTime;
            Canceled = false;
        }

        public AccountTemplate Sender { get; }
        public AccountTemplate Recipient { get; }
        public double AmountOfMoney { get; }
        public DateTime TransactionTime { get; }
        public int Id { get; }
        public bool Canceled { get; }
    }
}