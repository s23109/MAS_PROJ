using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    public class LandVehicle:VehicleSubType
    {
        public int? EnginePower { get; set; }
        public int? EngineTorque { get; set; }
        
        public PoiseSpecifics PoiseSpecifics { get; set; }
        
        public FuelSpecifics FuelSpecifics { get; set;}
    }
}
