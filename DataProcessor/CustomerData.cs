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

        public void CreateNew(Customer customer)    
        {
            _context.Add(customer);
            _context.SaveChanges();
        }

        public Customer EditCustomerById(int? id)
        {          
            var customer = _context.Customers
                .SingleOrDefault(c => c.Id == id);    
            
            return customer;
        }

        public void SaveEdits(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
