using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GettingStarted.Model
{
    public class MetadataBase :  IDataErrorInfo
    {
        public string Error
        {
            get { return ""; }
        }

        public string this[string propertyName]
        {
            get
            {
                return this.OnValidate(propertyName);
            }
        }

        protected virtual string OnValidate(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Invalid property name", propertyName);
            }

            string error = string.Empty;
            object value = this.GetValue(propertyName);
            List<ValidationResult> results = new List<ValidationResult>(1);
            ValidationContext context = new ValidationContext(this, null, null);
            context.MemberName = propertyName;
            bool result = Validator.TryValidateProperty(value, context, results);

            if (!result)
            {
                ValidationResult validationResult = results.First();
                error = validationResult.ErrorMessage;
            }

            return error;
        }

        private object GetValue(string propertyName)
        {
            var propertyDescriptor = TypeDescriptor.GetProperties(GetType()).Find(propertyName, false);
            if (propertyDescriptor == null)
            {
                throw new ArgumentException("Invalid property name", propertyName);
            }

            return propertyDescriptor.GetValue(this);
        }
    }
}
