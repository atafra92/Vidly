using AutoMapper;
using DataProcessor;
using DataProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly_MVCApp.Models;

namespace Vidly_MVCApp.Controllers.API
{
    public class CustomerAPI : IApiHelper<CustomerDto>
    {
        private readonly IEntityData<Customer, MembershipType> _customerData;
        private readonly IMapper _mapper;

        public CustomerAPI(IEntityData<Customer, MembershipType> customerData, IMapper mapper)
        {
            _customerData = customerData;
            _mapper = mapper;
        }

        public IEnumerable<CustomerDto> GetEntities(string query)
        {
            var customersList = _customerData.GetAll(query);
            var customers = _mapper.Map<List<CustomerDto>>(customersList);

            return customers;
        }

        public CustomerDto GetEntity(int id)
        {
            var customerById = _customerData.GetById(id);
            var customer = _mapper.Map<CustomerDto>(customerById);

            return customer;
        }

        public void SaveEntity(CustomerDto customerDto)
        {
            var customerToSave = _mapper.Map<Customer>(customerDto);

            _customerData.CreateNew(customerToSave);

            //update Id property in response action 
            customerDto.Id = customerToSave.Id;
        }

        public void UpdateEntity(int id, CustomerDto customerDto)
        {
            var customerInDb =  _customerData.EditById(id);

            _mapper.Map(customerDto, customerInDb);

            _customerData.SaveEditsAPI();
        }

        public void DeleteEntity(int id)
        {
           var customerToDelete = _customerData.EditById(id);
            _customerData.DeleteEntity(customerToDelete);
        }
    }
}
