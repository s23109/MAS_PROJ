using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    public class WaterVehicle:VehicleSubType
    {
        public int MinCrew { get; set; }
        public PurposeSpecifics PurposeSpecifics { get; set; }
        public FuelSpecifics FuelSpecifics { get; set;}
    }
}
