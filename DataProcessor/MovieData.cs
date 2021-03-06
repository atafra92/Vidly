﻿using DataProcessor.DataAccess;
using DataProcessor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProcessor
{
    public class MovieData : IEntityData<Movie, Genre> 
    {
        private VidlyDbContext _context;
        public MovieData(VidlyDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Movie> GetAll(string query)
        {
            IQueryable<Movie> moviesQuery = _context.Movies
                .Include(c => c.Genres)
                .Where(m => m.NumberAvailable > 0);

            if(!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Title.Contains(query));
            }

            return moviesQuery.ToList();
          
        }

        public Movie GetById(int? id)
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

        public Movie EditById(int? id)
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

        public void DeleteEntity(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public List<Genre> GetNavProperty()
        {
            return _context.Genres.ToList();
        }
    }
}
