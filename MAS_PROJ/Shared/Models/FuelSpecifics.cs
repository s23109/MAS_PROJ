using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MAS_PROJ.Shared.Models
{
    [Owned]
    public class FuelSpecifics
    {
        [Required]
        [EnumDataType(typeof(FuelTypes))]
        [IsValidFuelType]
        public FuelTypes? FuelType { get; set; }

        //Combustion Attributes
        public int? TankCapacity { get; set; }

        [EnumDataType(typeof(CombustionTypes))]
        [IsValidCombustionType]
        public CombustionTypes? CombustionType { get; set; }

        //Electric Attributes
        public int? BatteryCapacity { get; set; }
        [EnumDataType(typeof(BatteryTypes))]
        [IsValidBatteryType]
        public BatteryTypes? BatteryType { get; set; }

        //Other Attributes 

        public string? FuelTypeDescription { get; set; }

    }

    public class IsValidFuelType : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance;

            if (value == null) return new ValidationResult("Field is required");

            if ((Enum.IsDefined(typeof(FuelTypes), value)))
            {

                if (value is FuelTypes.NotDefined)
                {
                    return new ValidationResult("Field is required");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("Invalid Value");
            }
        }
    }
    public class IsValidCombustionType : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance;

            if (value == null) return new ValidationResult("Field is required");

            if ((Enum.IsDefined(typeof(CombustionTypes), value)))
            {

                if (value is CombustionTypes.NotDefined)
                {
                    return new ValidationResult("Field is required");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("Invalid Value");
            }
        }
    }

    public class IsValidBatteryType : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance;

            if (value == null) return new ValidationResult("Field is required");

            if ((Enum.IsDefined(typeof(BatteryTypes), value)))
            {

                if (value is BatteryTypes.NotDefined)
                {
                    return new ValidationResult("Field is required");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("Invalid Value");
            }
        }
    }
}
