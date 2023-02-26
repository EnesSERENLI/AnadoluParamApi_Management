using AnadoluParamApi.Base.Types;
using System.ComponentModel.DataAnnotations;

namespace AnadoluParamApi.Base.Attribute
{
    public class RoleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (value is null)
                    return new ValidationResult("Invalid Role field.");

                if (Enum.IsDefined(typeof(RoleEnum), value))
                    return ValidationResult.Success;
                else
                    return new ValidationResult("Invalid Role field.");
            }
            catch (Exception)
            {
                return new ValidationResult("Invalid Role field.");
            }
        }
    }
}
