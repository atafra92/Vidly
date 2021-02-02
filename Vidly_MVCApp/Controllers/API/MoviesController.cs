using DataProcessor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly_MVCApp.Models;

namespace Vidly_MVCApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieData _movieData;
        private readonly IApiHelper<MovieDto> _apiHelper;

        public MoviesController(IMovieData movieData, IApiHelper<MovieDto> apiHelper)
        {
            _movieData = movieData;
            _apiHelper = apiHelper;
        }

        // GET /api/movies      
        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> GetMovies()
        {
            //because method returns ActionResult<IEnumerable> we need to call ToList() method
            return _apiHelper.GetEntities().ToList();
        }

        //GET /api/movies/1
        [HttpGet("{id}")]
        public ActionResult<MovieDto> GetMovie(int id)
        {
            var movie = _apiHelper.GetEntity(id);

            if (movie == null)
            {
                NotFound();
            }

            return Ok(movie);
        }

        //POST /api/movies
        [HttpPost]
        public ActionResult<MovieDto> CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                NotFound();
            }

            _apiHelper.SaveEntity(movieDto);

            return CreatedAtAction(nameof(GetMovies), new { id = movieDto.Id }, movieDto);
        }

        // PUT /api/movies/1
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                NotFound();
            }

            var movieInDb = _movieData.EditMovieById(id);

            if (movieInDb == null)
            {
                NotFound();
            }

            _apiHelper.UpdateEntity(id, movieDto);

            return Ok();
        }

        //DELETE /api/movies/1
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movieInDb = _movieData.EditMovieById(id);

            if (movieInDb == null)
            {
                NotFound();
            }

            _apiHelper.DeleteEntity(id);

            return Ok();
        }
    }
}
