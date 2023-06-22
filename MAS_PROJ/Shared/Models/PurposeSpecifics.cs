using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MAS_PROJ.Shared.Models
{
    [Owned]
    public class PurposeSpecifics
    {
        [Required]
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
