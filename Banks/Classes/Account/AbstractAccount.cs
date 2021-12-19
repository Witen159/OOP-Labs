﻿namespace Banks.Classes.Account
{
    public abstract class AbstractAccount
    {
        public abstract void Refill(double value);

        public abstract void Withdrawal(double value);
        public abstract void Transfer(AbstractAccount account, double value);
    }
}