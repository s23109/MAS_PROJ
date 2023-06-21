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
    // Eg : Wheels, Tracks 
    [Owned]
    public class PoiseSpecifics
    {
        [Required]
        [EnumDataType(typeof(PoiseTypes))]
        [IsValidPoiseType]
        public PoiseTypes PoiseType { get; set; }

        //Wheel Atributes
        public int? WheelAmount { get; set; }
        public int? WheelWidth { get; set; }

        //Track Atributes
        public int? TrackLength { get; set; }
        public int? TrackWidth { get; set; }
    }

    public class IsValidPoiseType : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance;

            if (value == null) return new ValidationResult("Field is required");

            if ((Enum.IsDefined(typeof(PoiseTypes), value)))
            {

                if (value is PoiseTypes.NotDefined)
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
