using MaxBank.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxBank.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int Balance { get; set; }


        public string Transfer(int TransferToAccountNumber, int Amount)
        {
            if(this.Balance < Amount)
            {
                return "Insuffiecient amount, transfer failed.";
            }
            var accToTransferTo = BankRepository.GetAccountFromAccountNumber(TransferToAccountNumber);
            if(accToTransferTo == null)
            {
                return "Account not found with account number: " + TransferToAccountNumber;
            }
            this.Balance -= Amount;
            accToTransferTo.Balance += Amount;

            return "Transfer succeded, new balance is: "+this.Balance+"Kr";
        }
    }
}
