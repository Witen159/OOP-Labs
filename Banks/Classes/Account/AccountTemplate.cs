using System;
using System.Collections.Generic;
using Banks.Classes.Transaction;
using Banks.Tools;

namespace Banks.Classes.Account
{
    public abstract class AccountTemplate
    {
        private static int _currentId = 1;
        private double _money;
        private List<AbstractTransaction> _transactionHistory = new List<AbstractTransaction>();

        public AccountTemplate(double startMoney, DateTime currentTime, bool verification)
        {
            Id = _currentId++;
            Money = startMoney;
            this.CurrentTime = currentTime;
            Verification = verification;
        }

        public double Money
        {
            get { return Math.Round(_money, 2); }
            protected set => _money = value;
        }

        public DateTime CurrentTime { get; protected set; }
        public int Id { get; }
        public bool Verification { get; private set; }
        public IReadOnlyList<AbstractTransaction> TransactionHistory => _transactionHistory;

        public void IncreaseMoney(double amountOfMoney)
        {
            if (amountOfMoney < 0)
                throw new BankException("You should change account money only in positive amount of money");
            Money += amountOfMoney;
        }

        public virtual void ReduceMoney(double amountOfMoney)
        {
            if (amountOfMoney < 0)
                throw new BankException("You should change account money only in positive amount of money");
            Money -= amountOfMoney;
        }

        public virtual void PaymentOperation(DateTime timeOfTheNewPayment)
        {
        }

        public void AddTransaction(AbstractTransaction transaction)
        {
            _transactionHistory.Add(transaction);
        }

        // Изменение баланса в обход ограничений счета для отмены операций
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
    }
}