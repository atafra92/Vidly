using DataProcessor.DataAccess;
using DataProcessor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProcessor
{
    public class CustomerData : ICustomerData
    {
        private VidlyDbContext _context;
        public CustomerData(VidlyDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Customer> GetAll()
        {
            var Customers = _context.Customers.Include(c => c.MembershipTypes).ToList();

            return Customers;

        }
        public Customer GetCustomerById(int? id)
        {
            var customer = _context.Customers
                .Include(c => c.MembershipTypes)
                .Where(c => c.Id == id)
                .SingleOrDefault();

            return customer;
        }

        public void CreateNew(Customer customer)    
        {
            _context.Add(customer);
            _context.SaveChanges();

        }
    }
}
