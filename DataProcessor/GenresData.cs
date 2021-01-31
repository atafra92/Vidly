using DataProcessor.DataAccess;
using DataProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProcessor
{
    public class GenresData : IGenresData
    {
        private readonly VidlyDbContext _context;

        public GenresData(VidlyDbContext context)
        {
            _context = context;
        }
        public List<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }
    }
}
