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
                .Include(m => m.Genres)
                .Where(m => m.Id == id)
                .SingleOrDefault();

            return movie;
        }
        public void CreateNew(Movie movie)
        {
            _context.Add(movie);
            _context.SaveChanges();
        }

        public Movie EditMovieById(int? id)
        {
            var movie = _context.Movies
                .SingleOrDefault(m => m.Id == id);

            return movie;
        }

        public void SaveEditsMVC(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void SaveEditsAPI()
        {
            _context.SaveChanges();
        }

        public void DeleteMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public List<Genre> GetAllGenres()
        {
            return _context.Genres.ToList();
        }
    }
}
