using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BankingTest.Models
{
    [Index("Email", IsUnique = true)]
    [Index("Phone", IsUnique = true)]
    public class Customer
    {
        public Guid Id { get; set; }
        [StringLength(30)]
        public string FirstName { get; set; } = string.Empty;
        [StringLength(30)]
        public string LastName { get; set; } = string.Empty;
        [StringLength(60)]
        public string Email { get; set; } = string.Empty;
        [StringLength(20)]
        public string Phone {get; set;} = string.Empty;
        public int Tier {get; set;} = 1;
        public virtual Account? Account { get; set; }
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

    }
}