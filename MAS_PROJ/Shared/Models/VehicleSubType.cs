using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_PROJ.Shared.Models
{
    public class VehicleSubType
    {
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
