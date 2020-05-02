using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MIn18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Customer Customer = (Customer)validationContext.ObjectInstance;

            if (Customer.MembershipTypeId == MembershipType.UnKnown ||
                Customer.MembershipTypeId == MembershipType.PayAsYouGo
               )
            {
                return ValidationResult.Success;
            }

            if (Customer.BrithDate == null)
            {
                return new ValidationResult("Date of Birth Required!");
            }
            var age = DateTime.Today.Year - Customer.BrithDate.Value.Year;

            return (age > 18) ? ValidationResult.Success : new ValidationResult("Customer should be at aleast 18 years old to get membership");

        }
    }
}