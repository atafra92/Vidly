using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly_MVCApp.Models;

namespace Vidly_MVCApp.Controllers
{
    public class CustomerController : Controller
    {
        private List<Customer> ListCustomers()
        {
            var customers = new List<Customer>()
            {
                new Customer { Id = 1, Name = "Antonio"},
                new Customer { Id = 2, Name = "Ivana" }
            };

            return customers;
        }

        public IActionResult GetCustomers()
        {
            var customers = ListCustomers();
            
            return View(customers);
        }

        
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var customer = ListCustomers().FirstOrDefault(c => c.Id == id);

            return View(customer);
        }
     
        public ActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

      
        public ActionResult Edit(int id)
        {
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
