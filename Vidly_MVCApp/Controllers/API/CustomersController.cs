﻿using AutoMapper;
using DataProcessor;
using DataProcessor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly_MVCApp.Models;

namespace Vidly_MVCApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerData _customerData;
        private readonly IApiHelper<CustomerDto> _apiHelper;

        public CustomersController(ICustomerData customerData, IApiHelper<CustomerDto> apiHelper)
        {
            _customerData = customerData;
            _apiHelper = apiHelper;
        }

        // GET /api/customers      
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
        {
            //because method returns ActionResult<IEnumerable> we need to call ToList() method
            return _apiHelper.GetEntities().ToList();
        }

        //GET /api/customers/1
        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCustomer(int id)
        {
            var customer = _apiHelper.GetEntity(id);

            if(customer == null)
            {
                NotFound();
            }

            return Ok(customer);
        }

        //POST /api/customers
        [HttpPost]
        public ActionResult<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
            {
                NotFound();
            }

            _apiHelper.SaveEntity(customerDto);
      
           return CreatedAtAction(nameof(GetCustomers), new { id = customerDto.Id }, customerDto );
        }

        // PUT /api/customers/1
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                NotFound();
            }

            var customerInDb = _customerData.EditCustomerById(id);

            if(customerInDb == null)
            {
                NotFound();
            }

            _apiHelper.UpdateEntity(id, customerDto);

            return Ok();
        }

        //DELETE /api/customers/1
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customerInDb = _customerData.EditCustomerById(id);

            if (customerInDb == null)
            {
                NotFound();
            }

            _apiHelper.DeleteEntity(id);

            return Ok();
        }
    }
}
