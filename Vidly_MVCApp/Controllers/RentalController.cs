using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_MVCApp.Controllers
{
    public class RentalController : Controller
    {
        public IActionResult New()
        {
            return View();
        }
    }
}
