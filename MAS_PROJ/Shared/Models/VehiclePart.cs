using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    public class VehiclePart
    {
        //Association - Vehicle
        public int IdVehicle { get; set; }
        public Vehicle VehicleNavigation { get; set; }

        //Association - Part
        public int IdPart { get; set; }
        public Part PartNavigation { get; set; }
    }
}
