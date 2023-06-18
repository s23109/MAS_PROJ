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
    public class PurposeSpecifics
    {
        public HashSet<PurposeType> Purposes { get; set; } = new HashSet<PurposeType>();

        //Transport Attributes
        public int? ShipCapacity { get; set; }
        public HashSet<LoadType>? Loads { get; set; }

        //Passenger Attributes
        public int? MaxPassengers { get; set; }
        public int? MinLifeBoats { get; set; }

    }
}
