using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingTest.Data;
using BankingTest.Dto.Customer;
using BankingTest.Interfaces;
using BankingTest.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BankingTest.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BankContext _context;
        public CustomerRepository(BankContext context)
        {
            _context = context;
        }

        public bool CheckCustomer(Guid id)
        {
            var check = _context.Customers.Any(x => x.Id == id);
            return check;
        }

        public CustomerDto? DeleteCustomer(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerDto> GetAllCustomers()
        {
            var customers = _context.Customers.Include(y => y.Account).Select(x => x.ToCustomerDto()).ToList();
            return customers;
        }

        public CustomerDto? GetCustomer(Guid id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null){
                return null;
            }
            return customer.ToCustomerDto();
        }

        public CustomerDto RegisterCustomer(CreateCustomerDto customerDto)
        {
            var customer = customerDto.ToCustomerModel();
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer.ToCustomerDto();
        }

        public CustomerDto? UpdateCustomer(Guid id, UpdateCustomerDto customerDto)
        {
            throw new NotImplementedException();
        }

        public bool UpgradeTier(Guid id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if(customer == null){
                return false;
            }
            if(customer.Tier > 2){
                
                return false;
            }
            customer.Tier += 1;
            _context.SaveChanges();
            return true;
        }
    }
}