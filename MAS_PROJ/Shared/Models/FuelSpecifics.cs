using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MAS_PROJ.Shared.Models
{
    [Owned]
    public class FuelSpecifics
    {
        [Required]
        [EnumDataType(typeof(FuelTypes))]
        public FuelTypes? FuelType { get; set; }

        //Combustion Attributes
        public int? TankCapacity { get; set; }

        [EnumDataType(typeof(CombustionTypes))]
        public CombustionTypes? CombustionType { get; set; }

        //Electric Attributes
        public int? BatteryCapacity { get; set; }
        [EnumDataType(typeof(BatteryTypes))]
        public BatteryTypes? BatteryType { get; set; }

        //Other Attributes 

        public string? FuelTypeDescription { get; set; }

    }


}
