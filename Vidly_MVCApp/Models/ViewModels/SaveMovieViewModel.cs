using AutoMapper;
using DataProcessor;
using DataProcessor.Models;
using Vidly_MVCApp.Models;

namespace Vidly_MVCApp.Controllers
{
    internal class SaveMovieViewModel
    {
        private IMovieData _movieData;
        private IMapper _mapper;

        public SaveMovieViewModel(IMovieData movieData, IMapper mapper)
        {
            _movieData = movieData;
            _mapper = mapper;
        }

        public void SaveMovie(MovieDto movieDto)
        {
            var movieToSave = _mapper.Map<Movie>(movieDto);

            _movieData.CreateNew(movieToSave);
        }

        public void SaveMovieEdits(MovieDto movieDto)
        {
            var movieToEdit = _mapper.Map<Movie>(movieDto);

            _movieData.SaveEdits(movieToEdit);
        }
    }
}