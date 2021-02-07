using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly_MVCApp.Models.DTOs;

namespace Vidly_MVCApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalsAPI _rentalsAPI;

        public RentalsController(IRentalsAPI rentalsAPI)
        {
            _rentalsAPI = rentalsAPI;
        }
        [HttpPost]
        public IActionResult Create(RentalDto newRental)
        {
            if(!ModelState.IsValid)
            {
                BadRequest();
            }

            _rentalsAPI.SaveEntity(newRental);

            return Ok();
        }
    }
}
