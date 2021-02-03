using AutoMapper;
using DataProcessor;
using DataProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_MVCApp.Models.ViewModels
{
    public class MovieFormViewModel
    {
        private readonly IEntityData<Movie, Genre> _movieData;
        private readonly IMapper _mapper;

        public MovieFormViewModel(IEntityData<Movie, Genre> movieData, IMapper mapper)
        {
            _movieData = movieData;
            _mapper = mapper;
        }

        public void LoadGenres()
        {
            var genresList = _movieData.GetNavProperty();
            var genres = _mapper.Map<List<GenreDto>>(genresList);
            Genres = new List<GenreDto>(genres);
        }

        public void EditMovie(int? id)
        {
            LoadGenres();

            var movieEdit = _movieData.EditById(id);
            var movie = _mapper.Map<MovieDto>(movieEdit);
            Movie = movie;
        }

        public void SaveMovie(MovieDto movieDto)
        {
            var movieToSave = _mapper.Map<Movie>(movieDto);
            _movieData.CreateNew(movieToSave);
        }

        public void SaveMovieEdits(MovieDto movieDto)
        {
            var movieToEdit = _mapper.Map<Movie>(movieDto);
            _movieData.SaveEditsMVC(movieToEdit);
        }

        public MovieDto Movie { get; set; }
        public IEnumerable<GenreDto> Genres { get; set; }
        
    }
}
