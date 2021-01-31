using DataProcessor.DataAccess;
using DataProcessor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProcessor
{
    public class MovieData : IMovieData
    {
        private VidlyDbContext _context;
        public MovieData(VidlyDbContext context)
        {
            _context = context;
        }
        public List<Movie> GetAll()
        {
            var movies = _context.Movies.Include(c => c.Genres).ToList();

            return movies;
        }

        public Movie GetMovieById(int? id)
        {
            var movie = _context.Movies
                .Include(c => c.Genres)
                .Where(c => c.Id == id)
                .SingleOrDefault();

            return movie;
        }
    }
}
