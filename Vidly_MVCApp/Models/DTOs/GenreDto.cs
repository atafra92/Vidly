using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_MVCApp.Models
{
    public class GenreDto
    {
        public int Id { get; set; }

        [Display(Name = "Genre")]
        public string Name { get; set; }
    }
}
