using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    [Owned]
    public class PurposeSpecifics
    {
        [Required]
        [EnumDataType(typeof(PurposeTypes))]
        [IsValidPurposeType]
        public PurposeTypes PurposeType { get; set; }

        //Transport Attributes
        public int? ShipCapacity { get; set; }

        [EnumDataType(typeof(LoadTypes))]
        [IsValidLoadType]
        public LoadTypes? LoadType { get; set; }

        //Passenger Attributes
        public int? MaxPassengers { get; set; }
        public int? MinLifeBoats { get; set; }

    }

    public class IsValidPurposeType : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance;

            if (value == null) return new ValidationResult("Field is required");

            if ((Enum.IsDefined(typeof(PurposeTypes), value)))
            {

                if (value is PurposeTypes.NotDefined)
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

    public class IsValidLoadType : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance;

            if (value == null) return new ValidationResult("Field is required");

            if ((Enum.IsDefined(typeof(LoadTypes), value)))
            {

                if (value is LoadTypes.NotDefined)
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
