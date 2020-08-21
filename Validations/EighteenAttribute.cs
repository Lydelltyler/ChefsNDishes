using System;
using System.ComponentModel.DataAnnotations;

namespace ChefNDish.Validations {
    public class EighteenAttribute : ValidationAttribute {
        protected override ValidationResult IsValid (object value, ValidationContext validationContext) {

            if (value is DateTime) {
                DateTime check = (DateTime) value;
                if (DateTime.Now.AddYears (-18) > check) {
                    return ValidationResult.Success;
                } else {
                    return new ValidationResult ("Your to young to be wipping it in the kitchen");
                }
            } else {
                return new ValidationResult ("Please enter a Valid Date.");
            }

        }
    }

}