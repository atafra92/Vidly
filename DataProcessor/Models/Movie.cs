using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataProcessor.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]     
        public DateTime ReleaseDate { get; set; }

        [Required]
        [DataType(DataType.Date)]  
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        [Required]     
        public int NumberInStock { get; set; }

        public Genre Genres { get; set; }

        public int GenreId { get; set; }


    }
}
