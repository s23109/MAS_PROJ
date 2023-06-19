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
    public class PurposeSpecifics
    {
        [EnumDataType(typeof(PurposeTypes))]
        public PurposeTypes PurposeType { get; set; }

        //Transport Attributes
        public int? ShipCapacity { get; set; }

        [EnumDataType(typeof(LoadTypes))]
        public LoadTypes? LoadType { get; set; }

        //Passenger Attributes
        public int? MaxPassengers { get; set; }
        public int? MinLifeBoats { get; set; }

    }
}
