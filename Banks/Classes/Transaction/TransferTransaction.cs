using System;
using Banks.Classes.Account;

namespace Banks.Classes.Transaction
{
    public class TransferTransaction : AbstractTransaction
    {
        public TransferTransaction(AccountTemplate sender, AccountTemplate recipient, double amountOfMoney, DateTime currentTime)
            : base(sender, recipient, amountOfMoney, currentTime)
        {
            sender.ReduceMoney(amountOfMoney);
            recipient.IncreaseMoney(amountOfMoney);
        }
    }
}