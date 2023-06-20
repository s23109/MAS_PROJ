namespace MAS_PROJ.Server.Services.VehicleService
{
    public interface IVehicleService
    {
        Task<ServiceResponse<List<VehicleGet>>> GetVehiclesAsync();

        Task<ServiceResponse<VehicleDetailsGet>> GetVehicleDetailsByIdAsync(int IdVehicle);

        Task<ServiceResponse<VehicleGet>> GetVehicleByIdAsync(int IdVehicle);
    }
}
