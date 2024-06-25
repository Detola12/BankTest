using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingTest.Dto.Transaction;

namespace BankingTest.Interfaces
{
    public interface ITransactionRepository
    {
        public List<TransactionDto> GetAllTransactions();
        public TransactionDto? GetTransactionByCustomer(Guid id);
        public TransactionDto? StoreWithdraw(WithdrawDto withdrawDto);
        public TransactionDto? StoreDeposit(DepositDto depositDto);
    }
}