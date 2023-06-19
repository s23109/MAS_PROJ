using MAS_PROJ.Shared.Models.DTO.Response;
using MAS_PROJ.Shared;

namespace MAS_PROJ.Client.Services.VehicleService
{
    public interface IVehicleService
    {
        Task<ServiceResponse<List<VehicleGet>>> GetVehiclesAsync();

        Task<ServiceResponse<VehicleDetailsGet>> GetVehicleDetailsAsync(int Id);

        List<VehicleGet> Vehicles { get; set; }
        string Message { get; set; }
    }
}
