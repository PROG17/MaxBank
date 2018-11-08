using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MaxBank.ViewModels
{
    public class BankActionViewModel
    {
        [DisplayName("Accountnumber")]
        public int AccountId { get; set; }
        [DisplayName("Amount")]
        public int Amount { get; set; }

        public string Message { get; set; }
    }
}
