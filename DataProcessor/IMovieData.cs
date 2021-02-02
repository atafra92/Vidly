using DataProcessor.Models;
using System.Collections.Generic;

namespace DataProcessor
{
    public interface IMovieData
    {
        void CreateNew(Movie movie);
        Movie EditMovieById(int? id);
        List<Movie> GetAll();
        Movie GetMovieById(int? id);
        void SaveEditsMVC(Movie movie);
        void SaveEditsAPI();
        void DeleteMovie(Movie movie);
        List<Genre> GetAllGenres();

    }
}