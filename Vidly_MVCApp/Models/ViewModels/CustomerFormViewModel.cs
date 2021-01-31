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
        private readonly IMembershipTypeData _membershipTypeData;
        private readonly ICustomerData _customerData;
        private readonly IMapper _mapper;

        public CustomerFormViewModel(IMembershipTypeData membershipTypeData, ICustomerData customerData, IMapper mapper)
        {
            _membershipTypeData = membershipTypeData;
            _customerData = customerData;
            _mapper = mapper;
        }

        public void LoadMembershipTypes()
        {
            var membershipTypesList = _membershipTypeData.GetAll();
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

        public CustomerDto Customer { get; set; }
        public IEnumerable<MembershipTypeDto> MembershipTypes { get; set; }

    }
}
