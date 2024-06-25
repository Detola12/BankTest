using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingTest.Dto.Transaction
{
    public class WithdrawDto
    {
        public Guid CustomerId { get; set; }
        public decimal Amount { get; set; }
    }
}