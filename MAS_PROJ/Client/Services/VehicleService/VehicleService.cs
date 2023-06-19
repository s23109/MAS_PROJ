using MAS_PROJ.Shared;
using MAS_PROJ.Shared.Models.DTO.Response;
using System.Net.Http.Json;

namespace MAS_PROJ.Client.Services.VehicleService
{
    public class VehicleService : IVehicleService
    {
        private readonly HttpClient _httpClient;

        public VehicleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<VehicleGet> Vehicles { get; set; } = new List<VehicleGet>();
        public string Message { get; set; } = "Loading Vehicles";

        public async Task<ServiceResponse<VehicleDetailsGet>> GetVehicleDetailsAsync(int Id)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<VehicleDetailsGet>>($"/api/Vehicle/{Id}");
            return response;
        }

        public async Task<ServiceResponse<List<VehicleGet>>> GetVehiclesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<VehicleGet>>>("api/Vehicle");

            if (response != null && response.Data != null)
            {
                Vehicles = response.Data;
            }


            return response;
        }
    }
}
