using System;
using System.Collections.Generic;
using System.Text;
using MMT.Application.Models;

namespace ApplicationTests
{
    public static class Customers
    {
        public static List<Customer> GetCustomers()
        {
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    FirstName = "FirstName 1",
                    LastName = "Last Name 1",
                    CustomerId = "1234",
                    Email = "f1.n@test.com"
                },
                new Customer()
                {
                    FirstName = "FirstName 2",
                    LastName = "Last Name 2",
                    CustomerId = "0123",
                    Email = "f2.n@test.com"
                },
                new Customer()
                {
                    FirstName = "FirstName 3",
                    LastName = "Last Name 3",
                    CustomerId = "01234",
                    Email = "f3.n@test.com"
                },
            };

            return customers;
        }
    }
}
