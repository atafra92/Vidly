using DataProcessor.Models;
using System.Collections.Generic;

namespace DataProcessor
{
    public interface ICustomerData
    {
        IEnumerable<Customer> GetAll();
        Customer GetCustomerById(int? id);
        void CreateNew(Customer customer);
    }
}