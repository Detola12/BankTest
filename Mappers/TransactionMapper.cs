using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingTest.Dto.Transaction;
using BankingTest.Models;
using Microsoft.OpenApi.Extensions;

namespace BankingTest.Mappers
{
    public static class TransactionMapper
    {
        public static TransactionDto ToTransactionDto(this Transaction transaction){
            return new TransactionDto{
                Id = transaction.Id,
                CustomerId = transaction.CustomerId,
                AccountId = transaction.AccountId,
                Amount = transaction.Amount,
                TransactionType = transaction.TransactionType.GetDisplayName(),
                CreatedAt = transaction.CreatedAt,
            };
        }
    }
}