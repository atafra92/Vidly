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
        private readonly IMovieData _movieData;

        public MovieController(IMovieData movieData)
        {
            _movieData = movieData;
        }

        //GET: Movies
        public IActionResult GetMovies()
        {
            var movies = _movieData.GetAll();

            return View(movies);
        }

       public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var movie = _movieData.GetMovieById(id);

            if(movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
    }
}
