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
      
        [DataType(DataType.DateTime)] 
        public DateTime? BirthDate { get; set; }  

        //navigation property
        public MembershipType MembershipTypes { get; set; }

        public int MembershipTypeId { get; set; }



    }
}
