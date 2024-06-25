using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingTest.Dto.Transaction
{
    public class TransactionDto
    {
         public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string TransactionType { get; set; } = "";
        public decimal Amount { get; set; }
        public Guid AccountId { get; set; }
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }
}