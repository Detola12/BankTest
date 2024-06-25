using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingTest.Dto.Account;

namespace BankingTest.Interfaces
{
    public interface IAccountRepository
    {
        public List<AccountDto> GetAllAccounts();
        public List<AccountDto> GetAccounts(Guid id);
        public bool CheckAccount(Guid id);
        public AccountDto CreateAccount(string accountNo, Guid id);
    }
}