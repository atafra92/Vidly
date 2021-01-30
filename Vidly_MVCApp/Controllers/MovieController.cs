using DataProcessor;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly_MVCApp.Models;

namespace Vidly_MVCApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieEndpoint _movieEndpoint;

        public MovieController(IMovieEndpoint movieEndpoint)
        {
            _movieEndpoint = movieEndpoint;
        }

        //GET: Movies
        public IActionResult GetMovies()
        {
            var movies = _movieEndpoint.GetAll();

            return View(movies);
        }

       public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var movie = _movieEndpoint.GetMovieById(id);

            if(movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
    }
}
