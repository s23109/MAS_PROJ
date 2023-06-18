using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    [Owned]
    public class FuelSpecifics
    {
        public HashSet<FuelType> FuelTypes { get; set; } = new HashSet<FuelType>();

        //Combustion Attributes
        public int? TankCapacity { get; set; }
        public CombustionType? CombustionType { get; set; }

        //Electric Attributes
        public int? BatteryCapacity { get; set; }
        public BatteryType? BatteryType { get; set; }

        //Other Attributes 
        public string? FuelTypeDescription { get; set; }

    }

}
