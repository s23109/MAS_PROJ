namespace MAS_PROJ.Shared.Models.DTO.Response
{
    public class VehicleGet
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public DateTime ProductionStart { get; set; }
        public DateTime? ProductionEnd { get; set; }
        public string? VehicleNotes { get; set; }
    }
}
