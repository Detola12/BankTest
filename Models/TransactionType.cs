using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankingTest.Models
{
    public enum TransactionType
    {
        [Display(Name = "Withdraw")]
        WITHDRAW,
        [Display(Name = "Deposit")]
        DEPOSIT
    }
}