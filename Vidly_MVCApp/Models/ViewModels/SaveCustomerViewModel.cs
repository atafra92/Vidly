using AutoMapper;
using DataProcessor;
using DataProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_MVCApp.Models.ViewModels
{
    public class SaveCustomerViewModel
    {
        private readonly ICustomerData _customerData;
        private readonly IMapper _mapper;

        public SaveCustomerViewModel(ICustomerData customerData, IMapper mapper)
        {
            _customerData = customerData;
            _mapper = mapper;
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
    }
}
