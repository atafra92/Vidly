using AutoMapper;
using DataProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_MVCApp.Models.ViewModels
{
    public class GetCustomersViewModel
    {
        private readonly ICustomerData _customerData;
        private readonly IMembershipTypeData _membershipData;
        private readonly IMapper _mapper;

        public GetCustomersViewModel(ICustomerData customerData, IMembershipTypeData membershipData, IMapper mapper)
        {   
            _customerData = customerData;
            _membershipData = membershipData;
            _mapper = mapper;
        }
        public void LoadCustomers()
        {
            var customersList = _customerData.GetAll();
            var customers = _mapper.Map<List<CustomerDto>>(customersList);
            Customers = customers;
        }

        public void LoadMembershipTypes()
        {
            var membershipTypesList = _membershipData.GetAll();
            var membershipTypes = _mapper.Map<List<MembershipTypeDto>>(membershipTypesList);
            MembershipTypes = new List<MembershipTypeDto>(membershipTypes);
        }

        public IEnumerable<CustomerDto> Customers { get; set; }
        public IEnumerable<MembershipTypeDto> MembershipTypes { get; set; }

    }
}
