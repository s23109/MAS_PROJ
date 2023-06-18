using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    public class Vehicle
    {
        public Vehicle() {}

        public int IdVehicle { get; set; }
        public string Manufacturer { get; set; }
        public string Model{ get; set; }
        public DateTime ProductionStart { get; set; }
        public DateTime? ProductionEnd { get; set; }
        public string? VehicleNotes { get; set; }

        //Association - VehicleSubtype
        public IEnumerable<VehicleSubType> VehicleSubTypeNavigation { get; set; }

        //Association - VehiclePart
        public IEnumerable<VehiclePart> VehiclePartNavigation { get; set;}
    }
}
