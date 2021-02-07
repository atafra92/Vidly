using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataProcessor.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateRented { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateReturned { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Movie Movie { get; set; }


    }
}
