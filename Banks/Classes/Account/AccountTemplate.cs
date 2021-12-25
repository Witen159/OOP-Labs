using System;
using System.Collections.Generic;
using Banks.Classes.Transaction;
using Banks.Tools;

namespace Banks.Classes.Account
{
    public abstract class AccountTemplate
    {
        private static int _currentId = 1;
        private List<AbstractTransaction> _transactionHistory = new List<AbstractTransaction>();

        public AccountTemplate(double startMoney, DateTime currentTime, bool verification)
        {
            Id = _currentId++;
            Money = startMoney;
            this.CurrentTime = currentTime;
            Verification = verification;
        }

        public double Money { get; protected set; }
        public DateTime CurrentTime { get; protected set; }
        public int Id { get; }
        public bool Verification { get; private set; }
        public IReadOnlyList<AbstractTransaction> TransactionHistory => _transactionHistory;

        public void IncreaseMoney(double amountOfMoney)
        {
            Money += amountOfMoney;
        }

        public virtual void ReduceMoney(double amountOfMoney)
        {
            Money -= amountOfMoney;
        }

        public virtual void PaymentOperation(DateTime timeOfTheNewPayment)
        {
        }

        public void AddTransaction(AbstractTransaction transaction)
        {
            _transactionHistory.Add(transaction);
        }

        public void CancelOperation(double transactionAmount)
        {
            Money += transactionAmount;
        }

        public void СonfirmVerification()
        {
            Verification = true;
        }

        public void TransactionCheck(AbstractTransaction transaction)
        {
            if (!_transactionHistory.Contains(transaction))
                throw new BankException($"Transaction {transaction.Id}  does not belong to the account {Id}");
        }

        protected bool IsItLastDayOfMonth()
        {
            var firstDayOfMonth = new DateTime(CurrentTime.Year, CurrentTime.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            return CurrentTime == lastDayOfMonth;
        }

        protected int DaysPerYear()
        {
            return DateTime.IsLeapYear(CurrentTime.Year) ? 366 : 365;
        }
    }
}