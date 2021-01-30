using DataProcessor.Models;
using System.Collections.Generic;

namespace DataProcessor
{
    public interface ICustomerEndpoints
    {
        List<Customer> GetAll();
        Customer GetCustomerById(int? id);
    }
}