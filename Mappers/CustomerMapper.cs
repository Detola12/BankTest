using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingTest.Dto.Customer;
using BankingTest.Models;

namespace BankingTest.Mappers
{
    public static class CustomerMapper
    {
        public static Customer ToCustomerModel (this CreateCustomerDto customerDto){
            return new Customer{
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Email = customerDto.Email,
                Phone = customerDto.Phone,
            };
        }
        public static CustomerDto ToCustomerDto (this Customer customer){
            return new CustomerDto{
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone,
                Tier = customer.Tier,
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt,
            };
        }
    }
}