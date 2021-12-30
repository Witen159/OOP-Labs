using System;
using Banks.Classes.Account;

namespace Banks.Classes.Transaction
{
    public class TransferTransaction : AbstractTransaction
    {
        public TransferTransaction(AccountTemplate sender, AccountTemplate recipient, double amountOfMoney, DateTime currentTime)
            : base(sender, recipient, amountOfMoney, currentTime)
        {
            Sender.ReduceMoney(amountOfMoney);
            Sender.AddTransaction(this);

            Recipient.IncreaseMoney(amountOfMoney);
            Recipient.AddTransaction(this);
        }
    }
}