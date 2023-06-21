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

        [RequiredIf("SubType", SubType.Land)]
        public int? EnginePower { get; set; }

        [RequiredIf("SubType", SubType.Land)]
        public int? EngineTorque { get; set; }

        [RequiredIf("SubType", SubType.Water)]
        public int? MinCrew { get; set; }

        //Complex Attributes

        [Required]
        public FuelSpecifics? FuelSpecifics { get; set; }

        [RequiredIf("SubType", SubType.Land)]
        public PoiseSpecifics? PoiseSpecifics { get; set; }

        [RequiredIf("SubType", SubType.Water)]
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

    public class RequiredIfAttribute : ValidationAttribute
    {
        RequiredAttribute _innerAttribute = new RequiredAttribute();
        public string _dependentProperty { get; set; }
        public object _targetValue { get; set; }

        public RequiredIfAttribute(string dependentProperty, object targetValue)
        {
            this._dependentProperty = dependentProperty;
            this._targetValue = targetValue;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var field = validationContext.ObjectType.GetProperty(_dependentProperty);
            if (field != null)
            {
                var dependentValue = field.GetValue(validationContext.ObjectInstance, null);
                if ((dependentValue == null && _targetValue == null) || (dependentValue.Equals(_targetValue)))
                {
                    if (!_innerAttribute.IsValid(value))
                    {
                        string name = validationContext.DisplayName;
                        string specificErrorMessage = ErrorMessage;
                        if (specificErrorMessage.Length < 1)
                            specificErrorMessage = $"{name} is required.";

                        return new ValidationResult(specificErrorMessage, new[] { validationContext.MemberName });
                    }
                }
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(FormatErrorMessage(_dependentProperty));
            }
        }
    }


    public class DateMustBeAfterAttribute : ValidationAttribute
    {
        public DateMustBeAfterAttribute(string targetPropertyName)
            => TargetPropertyName = targetPropertyName;

        public string TargetPropertyName { get; }

        public string GetErrorMessage(string propertyName) =>
            $"'{propertyName}' must be after '{TargetPropertyName}'.";

        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {
            var targetValue = validationContext.ObjectInstance
                .GetType()
                .GetProperty(TargetPropertyName)
                ?.GetValue(validationContext.ObjectInstance, null);

            if ((DateTime?)value  == null)
            {
                return ValidationResult.Success;
            }

            if ((DateTime?)value < (DateTime?)targetValue)
            {
                var propertyName = validationContext.MemberName ?? string.Empty;
                return new ValidationResult(GetErrorMessage(propertyName), new[] { propertyName });
            }

            return ValidationResult.Success;
        }
    }

}

