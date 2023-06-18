using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public List<PoiseType> PoiseTypes { get; set; } = new List<PoiseType>();

        //Wheel Atributes
        public int? WheelAmount { get; set; }
        public int? WheelWidth { get; set; }

        //Track Atributes
        public int? TrackLength { get; set; }
        public int? TrackWidth { get; set; }
    }
}
