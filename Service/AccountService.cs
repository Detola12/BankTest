using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingTest.Interfaces;

namespace BankingTest.Service
{
    public class AccountService : IAccountService
    {
        public string GenerateAccountNumber()
        {
             Random random = new Random();
            string values = "ASME123456789";
            string accountNo = "";
            int length = 8;
            for (int i = 0; i < length; i++){
                accountNo += values[random.Next(values.Length)];
            }
            return accountNo;
        }
    }
}