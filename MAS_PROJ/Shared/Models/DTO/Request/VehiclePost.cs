﻿using MAS_PROJ.Shared.Models.DTO.Response;
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
        public DateTime? ProductionEnd { get; set; }
        public string? VehicleNotes { get; set; }

        //Subtype Attributes
        [Required]
        public string Name { get; set; }
        public string? SubtypeNotes { get; set; }

        [IsValidSubtype(ErrorMessage = "Please select valid subtype")]
        public SubType SubType { get; set; }

        [RequiredIfEnumProperty("SubType", typeof(SubType), SubType.NotDefined, SubType.Land)]

        public int? EnginePower { get; set; }
        [RequiredIfEnumProperty("SubType", typeof(SubType), SubType.NotDefined, SubType.Land)]
        public int? EngineTorque { get; set; }

        [RequiredIfEnumProperty("SubType", typeof(SubType), SubType.NotDefined, SubType.Water)]
        public int? MinCrew { get; set; }

        //Complex Attributes

        //Fuel
        [RequiredIfNotNull("SubType", SubType.NotDefined)]
        public FuelTypes? FuelType { get; set; }


        //Combustion Attributes

        [RequiredIfEnumProperty("FuelType", typeof(FuelTypes), FuelTypes.NotDefined, new[] { FuelTypes.Combustion, FuelTypes.CombustionElectric, FuelTypes.CombustionOther, FuelTypes.CombustionElectricOther })]
        public int? TankCapacity { get; set; }
        [RequiredIfEnumProperty("FuelType", typeof(FuelTypes), FuelTypes.NotDefined, new[] { FuelTypes.Combustion, FuelTypes.CombustionElectric, FuelTypes.CombustionOther, FuelTypes.CombustionElectricOther })]
        public CombustionTypes? CombustionType { get; set; }

        //Electric Attributes
        [RequiredIfEnumProperty("FuelType", typeof(FuelTypes), FuelTypes.NotDefined, new[] { FuelTypes.Electric, FuelTypes.CombustionElectric, FuelTypes.ElectricOther, FuelTypes.CombustionElectricOther })]
        public int? BatteryCapacity { get; set; }
        [RequiredIfEnumProperty("FuelType", typeof(FuelTypes), FuelTypes.NotDefined, new[] { FuelTypes.Electric, FuelTypes.CombustionElectric, FuelTypes.ElectricOther, FuelTypes.CombustionElectricOther })]
        public BatteryTypes? BatteryType { get; set; }

        //Other Attributes 

        [RequiredIfEnumProperty("FuelType", typeof(FuelTypes), FuelTypes.NotDefined, new[] { FuelTypes.Other, FuelTypes.CombustionOther, FuelTypes.ElectricOther, FuelTypes.CombustionElectricOther })]
        public string? FuelTypeDescription { get; set; }

        //Poise
        [RequiredIfEnumProperty("SubType", typeof(SubType), SubType.NotDefined, SubType.Land)]
        public PoiseTypes PoiseType { get; set; }

        //Wheel Atributes
        [RequiredIfEnumProperty("PoiseType", typeof(PoiseTypes), PoiseTypes.NotDefined, new[] { PoiseTypes.Wheels, PoiseTypes.WheelsTracks })]
        public int? WheelAmount { get; set; }
        [RequiredIfEnumProperty("PoiseType", typeof(PoiseTypes), PoiseTypes.NotDefined, new[] { PoiseTypes.Wheels, PoiseTypes.WheelsTracks })]
        public int? WheelWidth { get; set; }

        //Track Atributes
        [RequiredIfEnumProperty("PoiseType", typeof(PoiseTypes), PoiseTypes.NotDefined, new[] { PoiseTypes.Tracks, PoiseTypes.WheelsTracks })]
        public int? TrackLength { get; set; }
        [RequiredIfEnumProperty("PoiseType", typeof(PoiseTypes), PoiseTypes.NotDefined, new[] { PoiseTypes.Tracks, PoiseTypes.WheelsTracks })]
        public int? TrackWidth { get; set; }

        //Purpose
        [RequiredIfEnumProperty("SubType", typeof(SubType), SubType.NotDefined, SubType.Water)]
        public PurposeTypes PurposeType { get; set; }

        //Transport Attributes
        [RequiredIfEnumProperty("PurposeType", typeof(PurposeTypes), PurposeTypes.NotDefined, new[] { PurposeTypes.Transport, PurposeTypes.TransportPassenger })]
        public int? ShipCapacity { get; set; }
        [RequiredIfEnumProperty("PurposeType", typeof(PurposeTypes), PurposeTypes.NotDefined, new[] { PurposeTypes.Transport, PurposeTypes.TransportPassenger })]

        public LoadTypes? LoadType { get; set; }

        //Passenger Attributes
        [RequiredIfEnumProperty("PurposeType", typeof(PurposeTypes), PurposeTypes.NotDefined, new[] { PurposeTypes.Passenger, PurposeTypes.TransportPassenger })]
        public int? MaxPassengers { get; set; }
        [RequiredIfEnumProperty("PurposeType", typeof(PurposeTypes), PurposeTypes.NotDefined, new[] { PurposeTypes.Passenger, PurposeTypes.TransportPassenger })]
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

    public class RequiredIfNotNullAttribute : ValidationAttribute
    {
        private readonly string _dependentProperty;
        private readonly object _defaultValue;

        public RequiredIfNotNullAttribute(string dependentProperty, object defaultValue = null)
        {
            _dependentProperty = dependentProperty;
            _defaultValue = defaultValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dependentPropertyValue = validationContext.ObjectType.GetProperty(_dependentProperty)?.GetValue(validationContext.ObjectInstance);

            if (dependentPropertyValue != null && !Equals(dependentPropertyValue, _defaultValue) && value == null)
            {
                return new ValidationResult($"{validationContext.DisplayName} is required when {_dependentProperty} is not null.");
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
                return new ValidationResult($"{validationContext.DisplayName} is required when {_dependentProperty} is one of {_triggerValues}.");
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

}

