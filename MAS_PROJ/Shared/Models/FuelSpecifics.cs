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
    public class FuelSpecifics
    {
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
