using Fos.Models.TableViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Attributes
{
    public abstract class NumericCompareAttribute : ValidationAttribute
    {
        private string otherPropertyName;

        public NumericCompareAttribute(string otherPropertyName)
        {
            this.otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherProperty = validationContext.ObjectType.GetProperty(otherPropertyName).GetValue(validationContext.ObjectInstance);

            if (int.TryParse(value.ToString(), out int current) && int.TryParse(otherProperty.ToString(), out int other))
            {
                if (ValidCompare(current, other))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(ErrorMessage);
            }            
            throw new InvalidCastException("Values must be numeric");
        }        

        protected abstract bool ValidCompare(int current, int other);
    }
}
