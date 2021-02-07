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
    public class MovieAPI : IApiHelper<MovieDto>
    {
        private readonly IEntityData<Movie, Genre> _movieData;
        private readonly IMapper _mapper;

        public MovieAPI(IEntityData<Movie, Genre> movieData, IMapper mapper)
        {
            _movieData = movieData;
            _mapper = mapper;
        }

        public IEnumerable<MovieDto> GetEntities(string query)
        {
            var moviesList = _movieData.GetAll(query);
            var movies = _mapper.Map<List<MovieDto>>(moviesList);

            return movies;
        }

        public MovieDto GetEntity(int id)
        {
            var movieById = _movieData.GetById(id);
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
            var movieInDb = _movieData.EditById(id);

            _mapper.Map(movieDto, movieInDb);

            _movieData.SaveEditsAPI();
        }

        public void DeleteEntity(int id)
        {
            var movieToDelete = _movieData.EditById(id);
            _movieData.DeleteEntity(movieToDelete);
        }
    }
}
