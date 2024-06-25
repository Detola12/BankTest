using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingTest.Dto.Customer;
using BankingTest.Models;

namespace BankingTest.Interfaces
{
    public interface ICustomerRepository
    {
        public List<CustomerDto> GetAllCustomers();
        public CustomerDto? GetCustomer(Guid id);
        public CustomerDto RegisterCustomer(CreateCustomerDto customerDto);
        public CustomerDto? UpdateCustomer(Guid id, UpdateCustomerDto customerDto);
        public CustomerDto? DeleteCustomer(Guid id);
        public bool UpgradeTier(Guid id);
        public bool CheckCustomer(Guid id);
    }
}