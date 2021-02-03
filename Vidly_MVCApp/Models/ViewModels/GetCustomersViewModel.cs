//using AutoMapper;
//using DataProcessor;
//using DataProcessor.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Vidly_MVCApp.Models.ViewModels
//{
//    public class GetCustomersViewModel
//    {
//        private readonly IEntityData<Customer, MembershipType> _customerData;
//        private readonly IMapper _mapper;

//        public GetCustomersViewModel(IEntityData<Customer, MembershipType> customerData, IMapper mapper)
//        {
//            _customerData = customerData;
//            _mapper = mapper;
//        }
//        public void LoadCustomers()
//        {
//            var customersList = _customerData.GetAll();
//            var customers = _mapper.Map<List<CustomerDto>>(customersList);
//            Customers = customers;
//        }

//        public IEnumerable<CustomerDto> Customers { get; set; }
//        public IEnumerable<MembershipTypeDto> MembershipTypes { get; set; }

//    }
//}
