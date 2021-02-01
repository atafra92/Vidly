﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_MVCApp.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (CustomerDto)validationContext.ObjectInstance;

            if(customer.MembershipTypeId == MembershipTypeDto.Unknown || 
               customer.MembershipTypeId == MembershipTypeDto.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if(customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to be a member");
        }
    }
}