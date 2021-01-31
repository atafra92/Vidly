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
        private readonly ICustomerData _costumerEndpoints;
        private readonly IMapper _mapper;

        public GetCustomersViewModel(ICustomerData costumerEndpoints, IMapper mapper)
        {
            _costumerEndpoints = costumerEndpoints;
            _mapper = mapper;
        }
        public void LoadCustomers()
        {
            var customersList = _costumerEndpoints.GetAll();
            var customers = _mapper.Map<List<CustomerDto>>(customersList);

            Customers = customers;

        }
        public void GetCostumerById(int? id)
        {
            var costumerbyId = _costumerEndpoints.GetCustomerById(id);
            var customer = _mapper.Map<CustomerDto>(costumerbyId);

            Customer = customer;
        }

        public IEnumerable<CustomerDto> Customers { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
