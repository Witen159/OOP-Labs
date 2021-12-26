using System;
using System.Collections.Generic;
using Banks.Classes;
using Banks.Classes.Account;
using Banks.Classes.Bank;
using Banks.Classes.Client;
using Banks.Classes.Observer.Notification;
using Banks.Classes.Transaction;
using Banks.Tools;
using NUnit.Framework;

namespace Banks.Tests
{
    public class Tests
    {
        private CentralBank _centralBank;
        private ClientDirector _clientDirector;
        private ClientBuilder _clientBuilder;
        private DateTime _startTime;

        [SetUp]
        public void Setup()
        {
            _startTime = new DateTime(2022, 1, 1);
            _centralBank = CentralBank.GetInstance(_startTime);
            _clientDirector = new ClientDirector();
            _clientBuilder = new ClientBuilder();
            _clientDirector.Builder = _clientBuilder;
        }

        [Test]
        public void OperationLimitAndTransactionCancelTest()
        {
            _clientDirector.BuildFullClient("Ivan", "Ivanov", 12345 ,"alaska");
            Client ivan = _clientBuilder.GetClient();
            _clientDirector.BuildClientWithAddress("Denis", "Denisov", "alaska");
            Client denis = _clientBuilder.GetClient();
            var a = new List<int>() { 50000, 100000 };
            var b = new List<double>() { 1, 2, 3 };
            var percentAmount = new PercentAmount(a, b);

            Bank bank = _centralBank.RegisterNewBank("Тинькофф", 10000, 10000, percentAmount, 3, 1000);
            bank.RegisterNewClient(ivan);
            bank.RegisterNewClient(denis);

            AccountTemplate ivanDebit = bank.AddDebitAccount(ivan, 75000);
            AccountTemplate denisDebit = bank.AddDebitAccount(denis, 150000);

            AbstractTransaction transaction = bank.Transfer(ivanDebit, denisDebit, 30000);
            Assert.AreEqual(denisDebit.Money, 180000);
            Assert.AreEqual(ivanDebit.Money, 45000);

            bank.CancelOperation(transaction);
            Assert.AreEqual(denisDebit.Money, 150000);
            Assert.AreEqual(ivanDebit.Money, 75000);
            
            Assert.Throws<BankException>(() => bank.Withdrawal(denisDebit, 30000));
            Assert.Throws<BankException>(() => bank.Transfer(denisDebit, ivanDebit, 30000));
        }

        [Test]
        public void RunTimeTest()
        {
            _clientDirector.BuildFullClient("Ivan", "Ivanov", 12345 ,"alaska");
            Client client = _clientBuilder.GetClient();
            var a = new List<int>() { 50000, 100000 };
            var b = new List<double>() { 1, 2, 3 };
            var percentAmount = new PercentAmount(a, b);
            Bank bank = _centralBank.RegisterNewBank("Тинькофф", 10000, 10000, percentAmount, 3, 1000);
            bank.RegisterNewClient(client);
            
            AccountTemplate debit = bank.AddDebitAccount(client, 40000);
            AccountTemplate deposit = bank.AddDepositAccount(client, 40000, _centralBank.CurrentTime.AddDays(40));
            AccountTemplate credit = bank.AddCreditAccount(client, 40000);

            // В конце месяца на дебетовый и депозитный упали проценты
            _centralBank.NewDate(_centralBank.CurrentTime.AddDays(31));
            Assert.AreEqual(debit.Money, 40101.92);
            Assert.AreEqual(deposit.Money, 40033.97);
            
            // Депозитный счет закрылся, оставшийся остаток на процент зачислился на счет. Дебетовый не изменился
            _centralBank.NewDate(_centralBank.CurrentTime.AddDays(10));
            Assert.AreEqual(debit.Money, 40101.92);
            Assert.AreEqual(deposit.Money, 40044.94);
            
            // Прошел еще месяц. Депозитный счет не изменился (закрыт), дебетовый обновился
            _centralBank.NewDate(_centralBank.CurrentTime.AddDays(20));
            Assert.AreEqual(debit.Money, 40194.21);
            Assert.AreEqual(deposit.Money, 40044.94);
            
            // Кредитный счет в плюсе, комиссии не было
            Assert.AreEqual(credit.Money, 40000);

            // Кредитный счет ушел в минус, снималась комиссия
            bank.Withdrawal(credit, 41000);
            _centralBank.NewDate(_centralBank.CurrentTime.AddDays(5));
            Assert.AreEqual(credit.Money, -6000);
            
            // Баланс на кредитном счете упал ниже кредитного лимита
            Assert.Throws<BankException>(() => _centralBank.NewDate(_centralBank.CurrentTime.AddDays(5)));
        }

        [Test]
        public void NotificationTest()
        {
            _clientDirector.BuildFullClient("Ivan", "Ivanov", 12345 ,"alaska");
            Client client = _clientBuilder.GetClient();
            var a = new List<int>() { 50000, 100000 };
            var b = new List<double>() { 1, 2, 3 };
            var percentAmount = new PercentAmount(a, b);
            Bank bank = _centralBank.RegisterNewBank("Тинькофф", 10000, 10000, percentAmount, 3, 1000);
            bank.RegisterNewClient(client);
            
            bank.AddObserver(client);
            bank.BankParametersChanger.ChangeCommission(1500);
            bank.BankParametersChanger.ChangeOperationLimit(11000);
            bank.BankParametersChanger.ChangeCreditNegativeLimit(12000);
            
            Assert.IsTrue(client.Notifications[0] is CommissionNotification);
            Assert.IsTrue(client.Notifications[1] is OperationLimitNotification);
            Assert.IsTrue(client.Notifications[2] is CreditLimitNotification);
        }
    }
}