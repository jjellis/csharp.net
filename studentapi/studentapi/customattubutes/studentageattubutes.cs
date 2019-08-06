using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations

namespace studentapi.Controllers.customAtribute
{
    public class schoolageattribute
    {
        private int _minAge;
        private int _maxAge;

        public schoolageattribute(int minAge, int maxAge)
        {
            _minAge = minAge;
            _maxAge = maxAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime birthdate = (DateTime)value;
            int age = DateTime.Now.Year - birthdate.Year;
            if (age <= _minAge && >= _maxAge)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(GetErrorMessage());
            }
        }
        private string GetErrorMessage()
        {
            return $"the student age must be at least {_minAge} years old and cannot be older that {_maxAge} years old."
        }
    }

}
    