﻿using System.ComponentModel.DataAnnotations;

namespace InternetShop.Validation
{
    public class ValidateGender : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string gender = (string)value;

            if (gender != "None")
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Выберите пол");
            }
        }
    }
}
