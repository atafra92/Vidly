using AutoMapper;
using DataProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_MVCApp.Models.ViewModels
{
    public class MovieDisplayViewModel
    {
        private readonly IMovieData _movieData;
        private readonly IMapper _mapper;

        public MovieDisplayViewModel(IMovieData movieData, IMapper mapper)
        {
            _movieData = movieData;
            _mapper = mapper;
        }
        public void GetMovieById(int? id)
        {
            var movieById = _movieData.GetMovieById(id);
            var movie = _mapper.Map<MovieDto>(movieById);

            Movie = movie;
        }

        public MovieDto Movie { get; set; }
    }
}
