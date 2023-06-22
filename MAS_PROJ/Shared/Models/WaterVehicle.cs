namespace MAS_PROJ.Shared.Models
{
    public class WaterVehicle : VehicleSubType
    {
        public int? MinCrew { get; set; }

        public PurposeSpecifics PurposeSpecifics { get; set; }

        public FuelSpecifics FuelSpecifics { get; set; }
    }
}
