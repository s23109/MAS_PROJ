using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    // Eg : Wheels, Tracks 
    public class PoiseSpecifics
    {
        public List<PoiseTypes> PoiseTypes { get; set; } = new List<PoiseTypes>();

        //Wheel Atributes
        public int? WheelAmount { get; set; }
        public int? WheelWidth { get; set; }

        //Track Atributes
        public int? TrackLength { get; set; }
        public int? TrackWidth { get; set; }
    }
    public enum PoiseTypes { Wheels, Tracks }
}
