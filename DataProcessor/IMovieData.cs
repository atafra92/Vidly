using DataProcessor.Models;
using System.Collections.Generic;

namespace DataProcessor
{
    public interface IMovieData
    {
        List<Movie> GetAll();
        Movie GetMovieById(int? id);
    }
}