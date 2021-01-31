using AutoMapper;
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
            var viewModel = new GetCustomersViewModel(_customerData, _mapper);
            viewModel.LoadCustomers();

            return View(viewModel.Customers.ToList());
        }
    
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new GetCustomersViewModel(_customerData, _mapper);
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
            var viewModel = new LoadMembershipTypesViewModel(_membershipTypeData, _mapper);

            viewModel.LoadCustomerWithMembershipTypes();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerDto customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new LoadMembershipTypesViewModel(_membershipTypeData, _mapper)
                {
                    Customer = customer
                };
                viewModel.LoadCustomerWithMembershipTypes();
                return View(viewModel);
            }

            var saveCustomer = new SaveCustomerViewModel(_customerData, _mapper);
            saveCustomer.SaveCustomer(customer);

            return RedirectToAction(nameof(GetCustomers));
        }

      
        public IActionResult Edit(int id)
        {
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
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
