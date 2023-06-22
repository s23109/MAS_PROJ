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
