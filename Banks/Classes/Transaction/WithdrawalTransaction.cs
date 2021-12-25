using System;
using Banks.Classes.Account;

namespace Banks.Classes.Transaction
{
    public class WithdrawalTransaction : AbstractTransaction
    {
        public WithdrawalTransaction(AccountTemplate sender, AccountTemplate recipient, double amountOfMoney, DateTime currentTime)
            : base(sender, recipient, amountOfMoney, currentTime)
        {
            sender.ReduceMoney(amountOfMoney);
        }
    }
}