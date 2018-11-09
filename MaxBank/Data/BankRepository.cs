using MaxBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxBank.Data
{
    public class BankRepository
    {
        public static List<Customer> Customers { get; set; }

        public static Account GetAccountFromAccountNumber(int AccountNumber)
        {
            foreach (var item in Customers)
            {
                var acc = item.Accounts.Where(x => x.Id == AccountNumber).FirstOrDefault();
                if(acc != null)
                {
                    return acc;
                }
            }
            return null;
        }

        public BankRepository()
        {
            if (Customers == null)
            {
            Customers = new List<Customer>()
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

            }

        }
        public void Withdraw(int input, int accountId)
        {

            Customers.FirstOrDefault(c => c.Accounts.Select(a => a.Id == accountId).First()).Accounts.FirstOrDefault(a => a.Id == accountId).Balance -= input;

        }

        public void Deposit(int input, int accountId)
        {
            Customers.FirstOrDefault(c => c.Accounts.Select(a => a.Id == accountId).First()).Accounts.FirstOrDefault(a => a.Id == accountId).Balance += input;
      
        }

    }
}



