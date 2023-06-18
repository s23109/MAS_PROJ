namespace MAS_PROJ.Server.Services.VehicleService
{
    public interface IVehicleService
    {
        Task<ServiceResponse<List<Vehicle>>> GetVehiclesAsync();


    }
}
