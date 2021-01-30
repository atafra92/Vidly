using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataProcessor.Models
{
    public class MembershipType
    {
        public int Id { get; set; }

        [Display(Name = "Membership Type")]
        public string Name { get; set; }

        [Display(Name = "Sign up Fee")]
        public decimal SignUpFee { get; set; }

        [Display(Name = "Duration In Months")]
        public byte DurationInMonths { get; set; }

        [Display(Name = "Discount Rate")]
        public byte DiscountRate { get; set; }

    }
}
