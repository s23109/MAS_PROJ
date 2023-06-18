using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    public class VehicleSubType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSubtype { get; set; }
        public string? Name { get; set; }
        public string? SubtypeNotes { get; set; }

        //Association - Vehicle
        public int? IdVehicle { get; set; }
        [ForeignKey("IdVehicle")]
        public Vehicle VehicleNavigation { get; set; }

    }
}
