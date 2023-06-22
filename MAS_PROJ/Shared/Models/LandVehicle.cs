namespace MAS_PROJ.Shared.Models
{
    public class LandVehicle : VehicleSubType
    {
        public int? EnginePower { get; set; }
        public int? EngineTorque { get; set; }

        public PoiseSpecifics PoiseSpecifics { get; set; }

        public FuelSpecifics FuelSpecifics { get; set; }
    }
}
