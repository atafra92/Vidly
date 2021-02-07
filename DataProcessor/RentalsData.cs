using DataProcessor.DataAccess;
using DataProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProcessor
{
    public class RentalsData : IRentalsData
    {
        private readonly VidlyDbContext _context;

        public RentalsData(VidlyDbContext context)
        {
            _context = context;
        }

        public void CreateNewRental(int customerId, List<int> movieIds)
        {
            var customer = _context.Customers.Single(c => c.Id == customerId);

            var movies = _context.Movies.Where(m => movieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {             
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
                movie.NumberAvailable--;

            }
            _context.SaveChanges();

        }
    }
}
