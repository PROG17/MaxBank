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

            Assert.Equal(200, account.Balance);
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
        public void Check_Balance_Transfer_From_Account()
        {
            BankRepository.Customers[0].Accounts[0].Transfer(2, 200);

            Assert.Equal(0, BankRepository.Customers[0].Accounts[0].Balance);
        }

        [Fact]
        public void Check_Balance_Transfer_To_Account()
        {
            BankRepository.Customers[0].Accounts[0].Transfer(2, 200);

            Assert.Equal(450, BankRepository.Customers[1].Accounts[0].Balance);
        }

        [Fact]
        public void Check_Over_Transfer_From_Account()
        {
            var initialBalance1 = BankRepository.Customers[1].Accounts[0].Balance;
            var initialBalance = BankRepository.Customers[0].Accounts[0].Balance;

            var result = BankRepository.Customers[0].Accounts[0].Transfer(2, 2000);

            Assert.Equal(initialBalance1, BankRepository.Customers[1].Accounts[0].Balance);
            Assert.Equal(initialBalance, BankRepository.Customers[0].Accounts[0].Balance);
            Assert.Equal("Täckning saknas", result);
        }
    }
}
