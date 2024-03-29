﻿using System;
using System.Collections.Generic;
using Banks.Classes.Account;
using Banks.Classes.Observer;
using Banks.Classes.Observer.Notification;
using Banks.Tools;

namespace Banks.Classes.Client
{
    public class Client : IObserver
    {
        private List<AccountTemplate> _accounts = new List<AccountTemplate>();
        private List<INotification> _notifications = new List<INotification>();
        public string Name { get; internal set; }
        public string Surname { get; internal set; }
        public string Address { get; internal set; } = null;
        public int PassportNumber { get; internal set; } = 0;
        public bool Verification { get; internal set; }
        public int Id { get; internal set; }
        public IReadOnlyList<AccountTemplate> Accounts => _accounts;
        public IReadOnlyList<INotification> Notifications => _notifications;

        public void AddAccount(AccountTemplate newAccount)
        {
            _accounts.Add(newAccount);
        }

        public void SetAddress(string address)
        {
            Address = address;
            VerificationChek();
        }

        public void SetPassport(int passportNumber)
        {
            if (PassportNumber != 0)
                throw new BankException("Passport number already added");
            PassportNumber = passportNumber;
            VerificationChek();
        }

        public void Update(INotification notification)
        {
            _notifications.Add(notification);
        }

        private void VerificationChek()
        {
            Verification = Address != null && PassportNumber != 0;
            if (Verification)
            {
                foreach (AccountTemplate account in _accounts)
                {
                    account.СonfirmVerification();
                }
            }
        }
    }
}