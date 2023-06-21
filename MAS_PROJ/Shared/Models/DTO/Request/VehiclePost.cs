using MAS_PROJ.Shared.Models.DTO.Response;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace MAS_PROJ.Shared.Models.DTO.Request
{
    public class VehiclePost : IValidatableObject
    {
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public DateTime ProductionStart { get; set; }
        public DateTime? ProductionEnd { get; set; }
        public string? VehicleNotes { get; set; }

        //Subtype Attributes
        [Required]
        public string Name { get; set; }
        public string? SubtypeNotes { get; set; }

        [IsValidSubtype(ErrorMessage = "Please select valid subtype")]
        public SubType SubType { get; set; }

        public int? EnginePower { get; set; }

        public int? EngineTorque { get; set; }

        
        public int? MinCrew { get; set; }

        //Complex Attributes

        [Required]
        public FuelSpecifics? FuelSpecifics { get; set; }

        
        public PoiseSpecifics? PoiseSpecifics { get; set; }

        
        public PurposeSpecifics? PurposeSpecifics { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ProductionStart > ProductionEnd)
            {
                
                yield return new ValidationResult("asdads");
            }
        }
    }

    public class IsValidSubtype : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            if (Enum.IsDefined(typeof(SubType), value))
            {
                if (value is SubType.NotDefined) return false;
                else
                {
                    return true;
                }

            }

            return false;
        }
    }


}

