using System;
using Banks.Classes.Account;
using Banks.Tools;

namespace Banks.Classes.Transaction
{
    public class CancelTransaction : AbstractTransaction
    {
        public CancelTransaction(AbstractTransaction transaction)
            : base(transaction.Sender, transaction.Recipient, transaction.AmountOfMoney, transaction.TransactionTime)
        {
            if (transaction is CancelTransaction)
                throw new BankException("You cant cancel CancelTransaction");
            if (Sender != null)
            {
                Sender.CancelOperation(AmountOfMoney);
                Sender.AddTransaction(this);
            }

            if (Recipient != null)
            {
                Recipient.CancelOperation(-AmountOfMoney);
                Recipient.AddTransaction(transaction);
            }
        }
    }
}