using AutoMapper;
using DataProcessor;
using DataProcessor.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly_MVCApp.Models;
using Vidly_MVCApp.Models.ViewModels;

namespace Vidly_MVCApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IEntityData<Movie, Genre> _movieData;
        private readonly IMapper _mapper;

        public MovieController(IEntityData<Movie, Genre> movieData, IMapper mapper)
        {
            _movieData = movieData;
            _mapper = mapper;
        }

        //GET: Movies
        public IActionResult GetMovies()
        {
            var viewModel = new GetMoviesViewModel(_movieData, _mapper);
            viewModel.LoadMovies();           

            return View(viewModel.Movies.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var viewModel = new MovieDisplayViewModel(_movieData, _mapper);
            viewModel.GetMovieById(id);

            var movie = viewModel.Movie;

            if (movie == null)
            {
                return NotFound();
            }

            return View(viewModel.Movie);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new MovieFormViewModel(_movieData, _mapper)
            {
                Movie = new MovieDto()
            };

            viewModel.LoadGenres();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieDto movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(_movieData, _mapper)
                {
                    Movie = movie
                };
                viewModel.LoadGenres();
                return View(viewModel);
            }

            var saveToDb = new MovieFormViewModel(_movieData, _mapper);
            saveToDb.SaveMovie(movie);
            return RedirectToAction(nameof(GetMovies));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var viewModel = new MovieFormViewModel(_movieData, _mapper);
            viewModel.EditMovie(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MovieDto movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            var viewModel = new MovieFormViewModel(_movieData, _mapper);
            viewModel.SaveMovieEdits(movie);
            return RedirectToAction(nameof(GetMovies));
        }
    }
}
