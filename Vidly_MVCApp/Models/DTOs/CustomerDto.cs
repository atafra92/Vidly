using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_MVCApp.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Is subscribed to newsletter")]
        public bool IsSubsribedToNewsLetter { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        //navigation property
        public MembershipTypeDto MembershipTypes { get; set; }

        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
    }
}
