using AutoMapper;
using DataProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_MVCApp.Models.ViewModels
{
    public class GetMoviesViewModel
    {
        private readonly IMovieData _movieData;
        private readonly IMapper _mapper;

        public GetMoviesViewModel(IMovieData movieData, IMapper mapper)
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

        public void GetMovieById(int? id)
        {
            var movieById = _movieData.GetMovieById(id);
            var movie = _mapper.Map<MovieDto>(movieById);

            Movie = movie;
        }

        public IEnumerable<MovieDto> Movies { get; set; }
        public MovieDto Movie { get; set; }

    }
}
