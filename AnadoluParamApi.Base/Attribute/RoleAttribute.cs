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
                if ((string)value.ToString().ToLower() == RoleEnum.Admin.ToString().ToLower() || (string)value == RoleEnum.Member.ToString().ToLower())
                    return ValidationResult.Success;
                //if (Enum.IsDefined(typeof(RoleEnum), value))
                    
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
