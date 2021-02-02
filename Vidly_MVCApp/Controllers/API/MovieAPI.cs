using AutoMapper;
using DataProcessor;
using DataProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly_MVCApp.Models;

namespace Vidly_MVCApp.Controllers.API
{
    public class MovieAPI<T> : IApiHelper<MovieDto> where T : class
    {
        private readonly IMovieData _movieData;
        private readonly IMapper _mapper;

        public MovieAPI(IMovieData movieData, IMapper mapper)
        {
            _movieData = movieData;
            _mapper = mapper;
        }

        public IEnumerable<MovieDto> GetEntities()
        {
            var moviesList = _movieData.GetAll();
            var movies = _mapper.Map<List<MovieDto>>(moviesList);

            return movies;
        }

        public MovieDto GetEntity(int id)
        {
            var movieById = _movieData.GetMovieById(id);
            var movie = _mapper.Map<MovieDto>(movieById);

            return movie;
        }

        public void SaveEntity(MovieDto movieDto)
        {
            var movieToSave = _mapper.Map<Movie>(movieDto);

            _movieData.CreateNew(movieToSave);

            movieDto.Id = movieToSave.Id;
        }

        public void UpdateEntity(int id, MovieDto movieDto)
        {
            var movieInDb = _movieData.EditMovieById(id);

            _mapper.Map(movieDto, movieInDb);

            _movieData.SaveEditsAPI();
        }

        public void DeleteEntity(int id)
        {
            var movieToDelete = _movieData.EditMovieById(id);
            _movieData.DeleteMovie(movieToDelete);
        }
    }
}
