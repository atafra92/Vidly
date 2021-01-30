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
        private readonly ICustomerEndpoints _customerEndpoints;

        public CustomerController(ICustomerEndpoints customerEndpoints)
        {
            _customerEndpoints = customerEndpoints;
        }

        public IActionResult GetCustomers()
        {

            var customers = _customerEndpoints.GetAll();

            return View(customers);
        }
    
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerEndpoints.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
     
        public IActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
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
