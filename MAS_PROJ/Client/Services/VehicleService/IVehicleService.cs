using MAS_PROJ.Shared.Models.DTO.Response;
using MAS_PROJ.Shared;
using MAS_PROJ.Shared.Models.DTO.Request;

namespace MAS_PROJ.Client.Services.VehicleService
{
    public interface IVehicleService
    {
        Task<ServiceResponse<List<VehicleGet>>> GetVehiclesAsync();

        Task<ServiceResponse<VehicleGet>> GetVehicleByIdAsync(int Id);

        Task<ServiceResponse<VehicleDetailsGet>> GetVehicleDetailsAsync(int Id);

        Task<ServiceResponse<VehiclePost>> CreateVehicleAsync(VehiclePost newVehicle);
        Task<ServiceResponse<VehiclePost>> AddVehicleSubTypeAsync(VehiclePost newVehicle, int VehicleId);

        List<VehicleGet> Vehicles { get; set; }
        string Message { get; set; }
    }
}
