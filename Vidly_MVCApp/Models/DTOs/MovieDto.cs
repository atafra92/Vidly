using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_MVCApp.Models
{
    public class MovieDto
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        public GenreDto Genres { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }
    }
}
