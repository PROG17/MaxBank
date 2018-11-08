﻿using MaxBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxBank.Data
{
    public class BankRepository
    {
        public List<Customer> Customers = new List<Customer>()
        {
            new Customer()
            {
                Id = 1,
                Name = "Korven",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                    Id = 1,
                    Balance = 200

                    },
                    new Account()
                    {
                    Id = 4,
                    Balance = 270

                    }
                }
            },
            new Customer()
            {
                Id = 2,
                Name = "Hästen",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                    Id = 2,
                    Balance = 250
                    }
                }
            },
             new Customer()
            {
                Id = 3,
                Name = "Hästen",
                Accounts = new List<Account>()
                {
                   new Account()
                    {
                    Id = 3,
                    Balance = 350
                    }
                }

            }
        };

        public void Withdraw(int input, int accountId)
        {

            var customer = Customers.FirstOrDefault(c => c.Accounts.Select(a => a.Id == accountId).First());
            var account = customer.Accounts.Where(a => a.Id == accountId).First();

            //Lägger till det man skrivit in
            account.Balance += input;


        }

        public void Deposit(int input, int accountId)
        {
            var customer = Customers.FirstOrDefault(c => c.Accounts.Select(a => a.Id == accountId).First());
            var account = customer.Accounts.Where(a => a.Id == accountId).First();

            //Tar bort det man skrivit in
            account.Balance -= input;

        }

    }
}



