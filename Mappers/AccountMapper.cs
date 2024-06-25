using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingTest.Dto.Account;
using BankingTest.Models;

namespace BankingTest.Mappers
{
    public static class AccountMapper
    {
        public static AccountDto ToAccountDto(this Account account){
            return new AccountDto{
                Id = account.Id,
                AccountNo = account.AccountNo,
                AccountBalance = account.AccountBalance,
                CustomerId = account.CustomerId,
            };
        }
    }
}