using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BankingTest.Models
{
    [Index("CustomerId", IsUnique = true)]
    [Index("AccountNo", IsUnique = true)]
    public class Account
    {
        public Guid Id {get; set;}
        public Guid CustomerId {get; set;}
        public string AccountNo {get;set;} = string.Empty;
        public decimal AccountBalance {get; set;} = 0;
        [ForeignKey("CustomerId")]
        public Customer? Customer {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }
}