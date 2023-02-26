using AnadoluParamApi.Base.Types;
using System.ComponentModel.DataAnnotations;

namespace AnadoluParamApi.Base.Attribute
{
    public class UnitTypeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (value is null)
                    return new ValidationResult("Invalid UnitType name field.");

                if (Enum.IsDefined(typeof(UnitTypeEnum), value))
                    return ValidationResult.Success;
                else
                    return new ValidationResult("Invalid UnitType field.");
            }
            catch (Exception)
            {
                return new ValidationResult("Invalid UnitType field.");
            }
        }
    }
}
