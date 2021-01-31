using AutoMapper;
using DataProcessor;
using DataProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_MVCApp.Models.ViewModels
{
    public class LoadMembershipTypesViewModel
    {
        private readonly IMembershipTypeData _membershipTypeData;
        private readonly IMapper _mapper;

        public LoadMembershipTypesViewModel(IMembershipTypeData membershipTypeData, IMapper mapper)
        {
            _membershipTypeData = membershipTypeData;
            _mapper = mapper;
        }

        public void LoadCustomerWithMembershipTypes()
        {
            var membershipTypesList = _membershipTypeData.GetAll();

            var membershipTypes = _mapper.Map<List<MembershipTypeDto>>(membershipTypesList);

            MembershipTypes = new List<MembershipTypeDto>(membershipTypes);
            Customer = new CustomerDto();
        }

        public CustomerDto Customer { get; set; }
        public IEnumerable<MembershipTypeDto> MembershipTypes { get; set; }

    }
}
