using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaxBank.Data;
using MaxBank.Models;
using MaxBank.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MaxBank.Controllers
{
    public class BankController : Controller
    {
        private readonly BankRepository _bankRepository;
        
        public BankController(BankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public IActionResult Index()
        {
            var vm = new BankActionViewModel();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(string button, int accountId, int amount)
        {
            var vm = new BankActionViewModel();
            var customer = BankRepository.Customers.FirstOrDefault(c => c.Accounts.Select(a => a.Id == accountId).First());

            if (customer != null)
            {

                var balance = customer.Accounts.FirstOrDefault(a => a.Id == accountId).Balance;

                if (button == "Withdraw")
                {
                    if (amount > balance)
                    {
                        vm.Message = "Withdraw failed! You cannot withdraw that amount!";
                        return View(vm);
                    }

                    _bankRepository.Withdraw(amount, accountId);

                    vm.Message = "Withdraw succeeded, your new balance is: " + customer.Accounts.FirstOrDefault(a => a.Id == accountId).Balance;

                }
                else if (button == "Deposit")
                {

                    _bankRepository.Deposit(amount, accountId);
                    vm.Message = "You deposited " + amount + " your new balance is: " + customer.Accounts.FirstOrDefault(a => a.Id == accountId).Balance;
                }
            }
            else
            {
                vm.Message = "Wrong account number!";
            }


            return View(vm);
        }

        [HttpGet]
        public IActionResult TransferMoney()
        {
            return View("TransferMoney");
        }

        [HttpPost]
        public IActionResult TransferMoney(TransferViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                vm.Message = "Failed to transfer, please check your inputs.";
                return View("TransferMoney", vm);
            };
            var acc = BankRepository.GetAccountFromAccountNumber(vm.FromAccountId);
            if (acc == null)
            {
                vm.Message = "Wrong account information. No accounts found with account number: " + vm.FromAccountId;
            }
            else
            {
                vm.Message = BankRepository.GetAccountFromAccountNumber(vm.FromAccountId).Transfer(vm.ToAccountId, vm.Amount);
            }

            return View("TransferMoney",vm);
        }
    }
}