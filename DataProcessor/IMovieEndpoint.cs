using DataProcessor.Models;
using System.Collections.Generic;

namespace DataProcessor
{
    public interface IMovieEndpoint
    {
        List<Movie> GetAll();
        Movie GetMovieById(int? id);
    }
}