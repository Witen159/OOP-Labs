﻿using System;
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
            var clientsList = new List<Client>();
            Client currentClient;
            DateTime startTime = DateTime.Now;
            var centralBank = CentralBank.GetInstance(startTime);
            var clientDirector = new ClientDirector();
            var clientBuilder = new ClientBuilder();
            clientDirector.Builder = new ClientBuilder();

            Console.WriteLine("Please use command numbers is our application");
            Console.WriteLine();

            void StartMenu()
            {
                Console.WriteLine("Choose who you are:");
                Console.WriteLine("1. Bank Manager");
                Console.WriteLine("2. Client");
                Console.WriteLine("3. Exit Menu");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        BankManager();
                        break;
                    case 2:
                        LogIn();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Wrong command");
                        StartMenu();
                        return;
                }

                return;
            }

            void BankManager()
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Register new bank");
                Console.WriteLine("2. Banks list");
                Console.WriteLine("3. Return to start menu");
            }

            void ClientManager()
            {
            }

            void LogIn()
            {
                Console.WriteLine("1. Log in");
                Console.WriteLine("2. Register in system");
                Console.WriteLine("3. Cancel");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Type your full name:");
                        string fullname = Console.ReadLine();
                        currentClient = null;

                        foreach (Client client in clientsList)
                        {
                            if (client.Name + " " + client.Surname == fullname)
                            {
                                currentClient = client;
                            }
                        }

                        if (currentClient == null)
                        {
                            Console.WriteLine("Such a user is not registered");
                            LogIn();
                            return;
                        }

                        ClientManager();
                        break;
                    case 2:
                        Console.WriteLine("To have verified profile you need to add your address and passport");
                        Console.WriteLine("Type your name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Type your surname:");
                        string surname = Console.ReadLine();

                        foreach (Client client in clientsList)
                        {
                            if (name == client.Name && surname == client.Surname)
                            {
                                Console.WriteLine("This user is already registered");
                                LogIn();
                                return;
                            }
                        }

                        Console.WriteLine("Type your address or tap Enter");
                        string address = Console.ReadLine();

                        Console.WriteLine("Type your passport number or tap Enter");
                        string passport = Console.ReadLine();

                        if (address == string.Empty && passport == string.Empty)
                            clientDirector.BuildDefaultClient(name, surname);
                        else if (address == string.Empty)
                            clientDirector.BuildClientWithPassport(name, surname, Convert.ToInt32(passport));
                        else if (passport == string.Empty)
                            clientDirector.BuildClientWithAddress(name, surname, address);
                        else
                            clientDirector.BuildFullClient(name, surname, Convert.ToInt32(passport), address);

                        currentClient = clientBuilder.GetClient();
                        clientsList.Add(currentClient);

                        ClientManager();
                        break;
                    case 3:
                        StartMenu();
                        return;
                    default:
                        Console.WriteLine("Wrong command");
                        LogIn();
                        return;
                }
            }

            StartMenu();
        }
    }
}
