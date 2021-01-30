using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataProcessor.Models
{
   public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public bool IsSubsribedToNewsLetter { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }  

        //navigation property
        public MembershipType MembershipTypes { get; set; }

        public int MembershipTypeId { get; set; }



    }
}
