using AutoMapper;
using DataProcessor;
using DataProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_MVCApp.Models.ViewModels
{
    public class CustomerFormViewModel
    {
        private readonly ICustomerData _customerData;
        private readonly IMapper _mapper;

        public CustomerFormViewModel( ICustomerData customerData, IMapper mapper)
        {
            _customerData = customerData;
            _mapper = mapper;
        }

        public void LoadMembershipTypes()
        {
            var membershipTypesList = _customerData.GetAllMembershipTypes();
            var membershipTypes = _mapper.Map<List<MembershipTypeDto>>(membershipTypesList);
            MembershipTypes = new List<MembershipTypeDto>(membershipTypes);
        }

        public void EditCustomer(int? id)
        {          
            LoadMembershipTypes();

            var customerEdit = _customerData.EditCustomerById(id);
            var customer = _mapper.Map<CustomerDto>(customerEdit);
            Customer = customer;
        }

        public void SaveCustomer(CustomerDto customerDto)
        {
            var customerToSave = _mapper.Map<Customer>(customerDto);
            _customerData.CreateNew(customerToSave);
        }

        public void SaveCustomerEdits(CustomerDto customerDto)
        {
            var customerToEdit = _mapper.Map<Customer>(customerDto);
            _customerData.SaveEdits(customerToEdit);
        }

        public CustomerDto Customer { get; set; }
        public IEnumerable<MembershipTypeDto> MembershipTypes { get; set; }

    }
}
