using System;
using System.Linq;
using System.Windows.Controls;

namespace UpdateSourceExplicit.ValidationRules
{
    public class RequiredFieldValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "Value cannot be null.");
            }

            string valueAsString = value as string;
            if (valueAsString != null && string.IsNullOrEmpty(valueAsString))
            {
                return new ValidationResult(false, "Value cannot be empty.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
