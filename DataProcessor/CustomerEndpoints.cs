using DataProcessor.DataAccess;
using DataProcessor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProcessor
{
    public class CustomerEndpoints : ICustomerEndpoints
    {
        private VidlyDbContext _context;
        public CustomerEndpoints(VidlyDbContext context)
        {
            _context = context;
        }
        public List<Customer> GetAll()
        {
            var customers = _context.Customers.Include(c => c.MembershipTypes).ToList();

            return customers;

        }
        public Customer GetCustomerById(int? id)
        {
            var customer = _context.Customers
                .Include(c => c.MembershipTypes)
                .Where(c => c.Id == id)
                .SingleOrDefault();

            return customer;
        }
    }
}
