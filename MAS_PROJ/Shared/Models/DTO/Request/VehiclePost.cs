using MAS_PROJ.Shared.Models.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models.DTO.Request
{
    public class VehiclePost
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public DateTime ProductionStart { get; set; }
        public DateTime? ProductionEnd { get; set; }
        public string? VehicleNotes { get; set; }

        //Subtype Attributes
        public string Name { get; set; }
        public string? SubtypeNotes { get; set; }
        public SubType SubType { get; set; }

        public int? EnginePower { get; set; }
        public int? EngineTorque { get; set; }
        public int? MinCrew { get; set; }

        //Complex Attributes
        public FuelSpecifics? FuelSpecifics { get; set; }
        public PoiseSpecifics? PoiseSpecifics { get; set; }
        public PurposeSpecifics? PurposeSpecifics { get; set; }
    }
}
