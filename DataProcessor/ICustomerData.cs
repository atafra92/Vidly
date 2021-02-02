using DataProcessor.Models;
using System.Collections.Generic;

namespace DataProcessor
{
    public interface ICustomerData
    {
        IEnumerable<Customer> GetAll();
        Customer GetCustomerById(int? id);
        void CreateNew(Customer customer);
        Customer EditCustomerById(int? id);
        void SaveEditsMVC(Customer customer);
        List<MembershipType> GetAllMembershipTypes();
        void SaveEditsAPI();
        void DeleteCustomer(Customer customer);
    }
}