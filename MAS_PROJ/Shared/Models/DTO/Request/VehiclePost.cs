using MAS_PROJ.Shared.Models.DTO.Response;
using System.ComponentModel.DataAnnotations;

namespace MAS_PROJ.Shared.Models.DTO.Request
{
    public class VehiclePost
    {
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public DateTime ProductionStart { get; set; }

        [AfterDate("ProductionStart")]
        public DateTime? ProductionEnd { get; set; }
        public string? VehicleNotes { get; set; }

        //Subtype Attributes
        [Required]
        public string Name { get; set; }
        public string? SubtypeNotes { get; set; }

        [IsValidSubtype(ErrorMessage = "Please select valid subtype")]
        public SubType SubType { get; set; }

        [RequiredIfEnumProperty("SubType", typeof(SubType), SubType.NotDefined, SubType.Land)]
        [Range(1, int.MaxValue)]
        public int? EnginePower { get; set; }
        [RequiredIfEnumProperty("SubType", typeof(SubType), SubType.NotDefined, SubType.Land)]
        [Range(1, int.MaxValue)]
        public int? EngineTorque { get; set; }

        [RequiredIfEnumProperty("SubType", typeof(SubType), SubType.NotDefined, SubType.Water)]
        [Range(1, int.MaxValue)]
        public int? MinCrew { get; set; }

        //Complex Attributes

        //Fuel
        [RequiredIfEnumProperty("SubType", typeof(SubType), SubType.NotDefined, new[] { SubType.Land, SubType.Water })]
        [NotEqualToValue(FuelTypes.NotDefined)]

        public FuelTypes? FuelType { get; set; }


        //Combustion Attributes

        [RequiredIfEnumProperty("FuelType", typeof(FuelTypes), FuelTypes.NotDefined, new[] { FuelTypes.Combustion, FuelTypes.CombustionElectric, FuelTypes.CombustionOther, FuelTypes.CombustionElectricOther })]
        [Range(1, int.MaxValue)]
        public int? TankCapacity { get; set; }
        [RequiredIfEnumProperty("FuelType", typeof(FuelTypes), FuelTypes.NotDefined, new[] { FuelTypes.Combustion, FuelTypes.CombustionElectric, FuelTypes.CombustionOther, FuelTypes.CombustionElectricOther })]
        public CombustionTypes? CombustionType { get; set; }

        //Electric Attributes
        [RequiredIfEnumProperty("FuelType", typeof(FuelTypes), FuelTypes.NotDefined, new[] { FuelTypes.Electric, FuelTypes.CombustionElectric, FuelTypes.ElectricOther, FuelTypes.CombustionElectricOther })]
        [Range(1, int.MaxValue)]
        public int? BatteryCapacity { get; set; }
        [RequiredIfEnumProperty("FuelType", typeof(FuelTypes), FuelTypes.NotDefined, new[] { FuelTypes.Electric, FuelTypes.CombustionElectric, FuelTypes.ElectricOther, FuelTypes.CombustionElectricOther })]
        public BatteryTypes? BatteryType { get; set; }

        //Other Attributes 

        [RequiredIfEnumProperty("FuelType", typeof(FuelTypes), FuelTypes.NotDefined, new[] { FuelTypes.Other, FuelTypes.CombustionOther, FuelTypes.ElectricOther, FuelTypes.CombustionElectricOther })]
        public string? FuelTypeDescription { get; set; }

        //Poise
        [PoisePurposeValidator("SubType",SubType.Land,PoiseTypes.NotDefined)]
        public PoiseTypes PoiseType { get; set; }

        //Wheel Atributes
        [RequiredIfEnumProperty("PoiseType", typeof(PoiseTypes), PoiseTypes.NotDefined, new[] { PoiseTypes.Wheels, PoiseTypes.WheelsTracks })]
        [Range(1, int.MaxValue)]
        public int? WheelAmount { get; set; }
        [RequiredIfEnumProperty("PoiseType", typeof(PoiseTypes), PoiseTypes.NotDefined, new[] { PoiseTypes.Wheels, PoiseTypes.WheelsTracks })]
        [Range(1, int.MaxValue)]
        public int? WheelWidth { get; set; }

        //Track Atributes
        [RequiredIfEnumProperty("PoiseType", typeof(PoiseTypes), PoiseTypes.NotDefined, new[] { PoiseTypes.Tracks, PoiseTypes.WheelsTracks })]
        [Range(1, int.MaxValue)]
        public int? TrackLength { get; set; }
        [RequiredIfEnumProperty("PoiseType", typeof(PoiseTypes), PoiseTypes.NotDefined, new[] { PoiseTypes.Tracks, PoiseTypes.WheelsTracks })]
        [Range(1, int.MaxValue)]
        public int? TrackWidth { get; set; }

        //Purpose
        [PoisePurposeValidator("SubType", SubType.Water, PurposeTypes.NotDefined)]
        public PurposeTypes PurposeType { get; set; }

        //Transport Attributes
        [RequiredIfEnumProperty("PurposeType", typeof(PurposeTypes), PurposeTypes.NotDefined, new[] { PurposeTypes.Transport, PurposeTypes.TransportPassenger })]
        [Range(1, int.MaxValue)]
        public int? ShipCapacity { get; set; }
        [RequiredIfEnumProperty("PurposeType", typeof(PurposeTypes), PurposeTypes.NotDefined, new[] { PurposeTypes.Transport, PurposeTypes.TransportPassenger })]

        public LoadTypes? LoadType { get; set; }

        //Passenger Attributes
        [RequiredIfEnumProperty("PurposeType", typeof(PurposeTypes), PurposeTypes.NotDefined, new[] { PurposeTypes.Passenger, PurposeTypes.TransportPassenger })]
        [Range(1, int.MaxValue)]
        public int? MaxPassengers { get; set; }
        [RequiredIfEnumProperty("PurposeType", typeof(PurposeTypes), PurposeTypes.NotDefined, new[] { PurposeTypes.Passenger, PurposeTypes.TransportPassenger })]
        [Range(1, int.MaxValue)]
        public int? MinLifeBoats { get; set; }


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

    public class NotEqualToValue : ValidationAttribute
    {
        private readonly object _specifiedValue;

        public NotEqualToValue(object specifiedValue)
        {
            _specifiedValue = specifiedValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value.Equals(_specifiedValue))
            {
                return new ValidationResult($"{validationContext.DisplayName} cannot have the specified value.");
            }

            return ValidationResult.Success;
        }
    }


    public class RequiredIfEnumPropertyAttribute : ValidationAttribute
    {
        private readonly string _dependentProperty;
        private readonly Type _enumType;
        private readonly object _defaultValue;
        private readonly object[] _triggerValues;

        public RequiredIfEnumPropertyAttribute(string dependentProperty, Type enumType, object defaultValue, params object[] triggerValues)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException($"{enumType.Name} is not an enum type.");
            }

            _dependentProperty = dependentProperty;
            _enumType = enumType;
            _defaultValue = defaultValue;
            _triggerValues = triggerValues;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dependentPropertyValue = validationContext.ObjectType.GetProperty(_dependentProperty)?.GetValue(validationContext.ObjectInstance);

            if (!Equals(dependentPropertyValue, _defaultValue) &&
                IsTriggerValueMatch(dependentPropertyValue) &&
                IsValueNullOrEmpty(value))
            {
                return new ValidationResult($"{validationContext.DisplayName} is required when {_dependentProperty} has this value.");
            }

            return ValidationResult.Success;
        }

        private static bool IsValueNullOrEmpty(object value)
        {
            if (value == null)
                return true;

            if (value is string str)
                return string.IsNullOrWhiteSpace(str);

            if (value is IEnumerable<object> enumerable)
                return !enumerable.Cast<object>().Any();

            return false;
        }

        private bool IsTriggerValueMatch(object dependentPropertyValue)
        {
            if (_triggerValues.Contains(dependentPropertyValue))
            {
                return true;
            }
            else if (_triggerValues.Any() && _triggerValues.First().GetType().IsArray)
            {
                foreach (var triggerValue in _triggerValues)
                {
                    var triggerValuesArray = (Array)triggerValue;
                    if (triggerValuesArray.Cast<object>().Contains(dependentPropertyValue))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }


    public class PoisePurposeValidator : ValidationAttribute
    {
        //if subtype type is speficic value, then 

        private readonly string _dependentProperty;
        private readonly object _triggerValueDependant;
        private readonly object _defaultValueCurrent;

        public PoisePurposeValidator(string dependentProperty, object triggerValueDependant, object defaultValueCurrent)
        {
            _dependentProperty = dependentProperty;
            _triggerValueDependant = triggerValueDependant;
            _defaultValueCurrent = defaultValueCurrent;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dependantPropertyValue = validationContext.ObjectType.GetProperty(_dependentProperty)?.GetValue(validationContext.ObjectInstance);

            if (Equals(dependantPropertyValue, _triggerValueDependant) )
            {
                if (!Equals(value, _defaultValueCurrent))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"{validationContext.DisplayName} mustn't be {_defaultValueCurrent} when {_dependentProperty} is {_triggerValueDependant}");
                }
            }


            return ValidationResult.Success;
        }

    }
    public class AfterDateAttribute : ValidationAttribute
    {
        private readonly string _otherProperty;

        public AfterDateAttribute(string otherProperty)
        {
            _otherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(_otherProperty);

            if (otherPropertyInfo == null)
            {
                return new ValidationResult($"Property {_otherProperty} not found.");
            }

            var otherValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance);

            var currentValue = value as DateTime?;

            if (currentValue != null && otherValue is DateTime otherDateTime)
            {
                if (currentValue <= otherDateTime)
                {
                    return new ValidationResult($"{validationContext.DisplayName} must be after {_otherProperty}.");
                }
            }

            return ValidationResult.Success;
        }
    }

}

