using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MAS_PROJ.Shared.Models
{
    // Eg : Wheels, Tracks 
    [Owned]
    public class PoiseSpecifics
    {
        [Required]
        [EnumDataType(typeof(PoiseTypes))]
        public PoiseTypes PoiseType { get; set; }

        //Wheel Atributes
        public int? WheelAmount { get; set; }
        public int? WheelWidth { get; set; }

        //Track Atributes
        public int? TrackLength { get; set; }
        public int? TrackWidth { get; set; }
    }


}
