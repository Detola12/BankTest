using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingTest.Data;
using BankingTest.Dto.Account;
using BankingTest.Interfaces;
using BankingTest.Mappers;
using BankingTest.Models;

namespace BankingTest.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankContext _context;
        public AccountRepository(BankContext context)
        {
            _context = context;
        }

        public bool CheckAccount(Guid id)
        {
            var account = _context.Accounts.Any(x => x.CustomerId == id);
            return account;
        }

        public AccountDto CreateAccount(string accountNo, Guid id)
        {
            var account = new Account{
                CustomerId = id,
                AccountNo = accountNo,
            };

            _context.Accounts.Add(account);
            _context.SaveChanges();
            return account.ToAccountDto();
        }

        public List<AccountDto> GetAccounts(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<AccountDto> GetAllAccounts()
        {
            throw new NotImplementedException();
        }
    }
}