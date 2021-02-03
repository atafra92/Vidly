using AutoMapper;
using DataProcessor;
using DataProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_MVCApp.Models.ViewModels
{
    public class GetMoviesViewModel
    {
        private readonly IEntityData<Movie, Genre> _movieData;
        private readonly IMapper _mapper;

        public GetMoviesViewModel(IEntityData<Movie, Genre> movieData, IMapper mapper)
        {
            _movieData = movieData;
            _mapper = mapper;
        }

        public void LoadMovies()
        {
            var moviesList = _movieData.GetAll();
            var movies = _mapper.Map<List<MovieDto>>(moviesList);

            Movies = movies;
        }

        public IEnumerable<MovieDto> Movies { get; set; }
    }
}
