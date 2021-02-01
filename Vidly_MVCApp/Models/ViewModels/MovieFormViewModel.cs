using AutoMapper;
using DataProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_MVCApp.Models.ViewModels
{
    public class MovieFormViewModel
    {
        private readonly IMovieData _movieData;
        private readonly IGenresData _genresData;
        private readonly IMapper _mapper;

        public MovieFormViewModel(IMovieData movieData, IGenresData genresData, IMapper mapper  )
        {
            _movieData = movieData;
            _genresData = genresData;
            _mapper = mapper;
        }

        public void LoadGenres()
        {
            var genresList = _genresData.GetAll();
            var genres = _mapper.Map<List<GenreDto>>(genresList);
            Genres = new List<GenreDto>(genres);
        }

        public void EditMovie(int? id)
        {
            LoadGenres();

            var movieEdit = _movieData.EditMovieById(id);
            var movie = _mapper.Map<MovieDto>(movieEdit);
            Movie = movie;
        }

        public MovieDto Movie { get; set; }
        public IEnumerable<GenreDto> Genres { get; set; }
        
    }
}
