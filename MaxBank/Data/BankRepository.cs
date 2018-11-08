using MaxBank.Models;
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

    }
}



