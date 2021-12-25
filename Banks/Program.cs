using System;
using System.Collections.Generic;
using Banks.Classes;
using Banks.Classes.Account;
using Banks.Classes.Bank;
using Banks.Classes.Client;

namespace Banks
{
    internal static class Program
    {
        private static void Main()
        {
            ClientDirector clientDirector = new ClientDirector();
            ClientBuilder clientBuilder = new ClientBuilder();
            clientDirector.Builder = clientBuilder;
            clientDirector.BuildDefaultClient("Ivan", "Ivanov");
            Client client = clientBuilder.GetClient();
            var a = new List<int>() { 50000, 100000 };
            var b = new List<double>() { 1, 2, 3 };
            var percentAmount = new PercentAmount(a, b);
            var centralBank = CentralBank.GetInstance();
            Bank bank = centralBank.RegisterNewBank("Тинькоф", 10000, 10000, percentAmount, 3, 10000);
            bank.RegisterNewClient(client);
            AccountTemplate account = bank.AddCreditAccount(client, 10000);
            if (account is CreditAccount)
                Console.WriteLine("It works");
        }
    }
}
