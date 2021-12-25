using System;
using Banks.Classes.Account;

namespace Banks.Classes.Transaction
{
    public class RefillTransaction : AbstractTransaction
    {
        public RefillTransaction(AccountTemplate sender, AccountTemplate recipient, double amountOfMoney, DateTime currentTime)
            : base(sender, recipient, amountOfMoney, currentTime)
        {
            recipient.IncreaseMoney(amountOfMoney);
        }
    }
}