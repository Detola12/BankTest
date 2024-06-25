using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingTest.Dto.Account
{
    public class AccountDto
    {
        public Guid Id {get; set;}
        public Guid CustomerId {get; set;}
        public string AccountNo {get;set;} = string.Empty;
        public decimal AccountBalance {get; set;} = 0;
    }
}