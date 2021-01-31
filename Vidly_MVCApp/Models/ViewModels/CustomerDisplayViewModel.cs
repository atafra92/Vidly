using AutoMapper;
using DataProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_MVCApp.Models.ViewModels
{
    public class CustomerDisplayViewModel
    {
        private readonly ICustomerData _customerData;
        private readonly IMapper _mapper;

        public CustomerDisplayViewModel(ICustomerData customerData, IMapper mapper)
        {
            _customerData = customerData;
            _mapper = mapper;
        }
        public void GetCostumerById(int? id)
        {
            var costumerbyId = _customerData.GetCustomerById(id);
            var customer = _mapper.Map<CustomerDto>(costumerbyId);

            Customer = customer;
        }

        public CustomerDto Customer { get; set; }
    }
}
