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
        public List<FuelTypes>? FuelTypes { get; set; }

        //Combustion Attributes
        public int? TankCapacity { get; set; }
        public CombustionTypes? CombustionType { get; set; }

        //Electric Attributes
        public int? BatteryCapacity { get; set; }
        public BatteryTypes? BatteryType { get; set; }

        //Other Attributes 
        public string? FuelTypeDescription { get; set; }


    }

    public enum FuelTypes { Combustion, Electric, Other }

    public enum CombustionTypes { Diesel, Gasoline }

    public enum BatteryTypes { NMC, LMO, LFP, NCA}
}
