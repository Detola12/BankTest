using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingTest.Data;
using BankingTest.Dto.Transaction;
using BankingTest.Interfaces;
using BankingTest.Mappers;
using BankingTest.Models;

namespace BankingTest.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankContext _context;
        public TransactionRepository(BankContext context)
        {
            _context = context;
        }
        public List<TransactionDto> GetAllTransactions()
        {
            var transactions = _context.Transactions.Select(x=>x.ToTransactionDto()).ToList();
            return transactions;
        }

        public TransactionDto? GetTransactionByCustomer(Guid id)
        {
            var transaction = _context.Transactions.FirstOrDefault(x => x.CustomerId == id);
            if (transaction == null){
                return null;
            }
            return transaction.ToTransactionDto();
        }

        public TransactionDto? StoreDeposit(DepositDto depositDto)
        {
           
            var account = _context.Accounts.FirstOrDefault(x => x.CustomerId == depositDto.CustomerId);
            var customer = _context.Customers.FirstOrDefault(y => y.Id == depositDto.CustomerId);
            if (account == null){
                return null;
            }
            var transaction = new Transaction {
                CustomerId = depositDto.CustomerId,
                Amount = depositDto.Amount,
                AccountId = account.Id,
                TransactionType = TransactionType.DEPOSIT
            };
            if(customer.Tier == 1){
                if(account.AccountBalance + depositDto.Amount > 50000){
                    throw new Exception("Balance Exceeded");
                }
                else{
                    account.AccountBalance += depositDto.Amount;
                }
            }
            if(customer.Tier == 2){
                if(account.AccountBalance + depositDto.Amount > 100000){
                    throw new Exception("Balance Exceeded");
                }
                else{
                    account.AccountBalance += depositDto.Amount;
                }
            }
            if(customer.Tier == 3){
                account.AccountBalance += depositDto.Amount;
            }
            
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return transaction.ToTransactionDto();
            
        }

        public TransactionDto? StoreWithdraw(WithdrawDto withdrawDto)
        {
            var account = _context.Accounts.FirstOrDefault(x => x.CustomerId == withdrawDto.CustomerId);
            if (account == null){
                return null;
            }
            if(account.AccountBalance < withdrawDto.Amount){
                throw new Exception("Insufficient Balance");
            }
            var transaction = new Transaction {
                CustomerId = withdrawDto.CustomerId,
                Amount = withdrawDto.Amount,
                AccountId = account.Id,
            };
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return transaction.ToTransactionDto();
        }
    }
}