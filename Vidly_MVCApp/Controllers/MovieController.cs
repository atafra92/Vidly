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
        private List<Movie> ListMovies()
        {
            var movies = new List<Movie>
            {
                new Movie { Id = 1, Title = "Star Wars VI - Return of the Jedi" },
                new Movie { Id = 2, Title = "Star Wars V - The Empire Strikes Back" }
            };

            return movies;
        }
        //GET: Movies
        public IActionResult GetMovies()
        {
            var movies = ListMovies();

            return View(movies);
        }

       public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var movie = ListMovies().FirstOrDefault(m => m.Id == id);

            return View(movie);
        }
    }
}
