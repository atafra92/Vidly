﻿using AutoMapper;
using DataProcessor;
using DataProcessor.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly_MVCApp.Models;
using Vidly_MVCApp.Models.ViewModels;

namespace Vidly_MVCApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerData _customerData;
        private readonly IMembershipTypeData _membershipTypeData;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerData customerData, IMembershipTypeData membershipTypeData, IMapper mapper)
        {
            _customerData = customerData;
            _membershipTypeData = membershipTypeData;
            _mapper = mapper;
        }

        public IActionResult GetCustomers()
        {
            var viewModel = new GetCustomersViewModel(_customerData, _membershipTypeData, _mapper);
            viewModel.LoadCustomers();

            return View(viewModel.Customers.ToList());
        }
    
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var viewModel = new CustomerDisplayViewModel(_customerData, _mapper);
            viewModel.GetCostumerById(id);

            var customer = viewModel.Customer;

            if (customer == null)
            {
                return NotFound();
            }

            return View(viewModel.Customer);
        }
     
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CustomerFormViewModel(_membershipTypeData, _customerData, _mapper)
            {
                Customer = new CustomerDto()
            };
            viewModel.LoadMembershipTypes();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerDto customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel(_membershipTypeData, _customerData, _mapper)
                {
                    Customer = customer
                };
                viewModel.LoadMembershipTypes();
                return View(viewModel);
            }

            var saveCustomer = new SaveCustomerViewModel(_customerData, _mapper);
            saveCustomer.SaveCustomer(customer);

            return RedirectToAction(nameof(GetCustomers));
        }

        [HttpGet]      
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var viewModel = new CustomerFormViewModel(_membershipTypeData, _customerData, _mapper);           
            viewModel.EditCustomer(id);

            if(viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerDto customer)
        {
            if (!ModelState.IsValid)
            {
               return View(customer);
            }

            var viewModel = new SaveCustomerViewModel(_customerData, _mapper);
            viewModel.SaveCustomerEdits(customer);
            return RedirectToAction(nameof(GetCustomers));
        }

        public IActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
