﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models.DTO.Response
{
    public class VehicleDetailsGet
    {
        public int IdVehicle { get; set; } 
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public DateTime ProductionStart { get; set; }
        public DateTime? ProductionEnd { get; set; }
        public string? VehicleNotes { get; set; }
        public List<VehicleSubTypeGet> VehicleSubType { get; set; } = new List<VehicleSubTypeGet>();
    }
}
