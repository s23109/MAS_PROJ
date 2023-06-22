using MAS_PROJ.Shared;
using MAS_PROJ.Shared.Models.DTO.Request;
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

        public async Task<ServiceResponse<VehiclePost>> AddVehicleSubTypeAsync(VehiclePost newVehicle, int VehicleId)
        {
            
            try
            {
                var request = await _httpClient.PostAsJsonAsync($"/api/Vehicle/Create/{VehicleId}", newVehicle);
                if (!request.IsSuccessStatusCode)
                {
                    throw new Exception($"Error {request.StatusCode}");
                }
                return await request.Content.ReadFromJsonAsync<ServiceResponse<VehiclePost>>();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<VehiclePost>()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
            
            
        }

        public async Task<ServiceResponse<VehiclePost>> CreateVehicleAsync(VehiclePost newVehicle)
        {
            
            try
            {
                var request = await _httpClient.PostAsJsonAsync("/api/Vehicle/CreateNew", newVehicle);

                if (!request.IsSuccessStatusCode)
                {
                    throw new Exception($"Error {request.StatusCode}");
                }
                return await request.Content.ReadFromJsonAsync<ServiceResponse<VehiclePost>>();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<VehiclePost>()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ServiceResponse<VehicleGet>> GetVehicleByIdAsync(int Id)
        {
            var response = new ServiceResponse<VehicleGet>();

            if (Vehicles.Count != 0 && Vehicles.First(x => x.Id == Id) != null)
            {
                response.Data = Vehicles.First(x => x.Id == Id);

            }
            else
            {
                try
                {
                    response = await _httpClient.GetFromJsonAsync<ServiceResponse<VehicleGet>>($"/api/Vehicle/{Id}");
                }
                catch
                {
                    //If 404
                    return new ServiceResponse<VehicleGet>
                    {
                        Success = false,
                        Message = "Vehicle not found"
                    };
                }
            }

            return response;
        }

        public async Task<ServiceResponse<VehicleDetailsGet>> GetVehicleDetailsAsync(int Id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ServiceResponse<VehicleDetailsGet>>($"/api/Vehicle/Details/{Id}");
                return response;
            }
            catch
            {
                //If 404
                return new ServiceResponse<VehicleDetailsGet>
                {
                    Success = false,
                    Message = "Vehicle not found"
                };
            }
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
