using MaxBank.Data;
using System;
using System.Linq;
using Xunit;

namespace MaxBankTest
{
    public class MaxBankUnitTest
    {
        BankRepository BankRepository = new BankRepository();
        [Fact]
        public void Withdraw()
        {
            var input = 50;
            var customer = BankRepository.Customers.First();
            var account = customer.Accounts.First();
            account.Balance += input;


            Assert.Equal(250, account.Balance);
        }

        [Fact]
        public void Deposit()
        {
            var input = 50;
            var customer = BankRepository.Customers.First();
            var account = customer.Accounts.First();
            account.Balance -= input;

            Assert.Equal(150, account.Balance);
        }

        [Fact]
        public void try_withrdraw_too_much()
        {
            bool withdrawFailed;

            var input = 500;
            var customer = BankRepository.Customers.First();
            var account = customer.Accounts.First();

            account.Balance -= input;
            if (account.Balance < 0)
            {
                withdrawFailed = true;
            }
            else
            {
                withdrawFailed = false;
            }

            Assert.True(withdrawFailed);

        }

        [Fact]
        public void Transfer()
        {

        }
    }
}
