using MAS_PROJ.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace MAS_PROJ.Server.Services.VehicleService
{
    public class VehicleService : IVehicleService
    {
        private readonly MyDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public VehicleService(MyDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<List<Vehicle>>> GetVehiclesAsync()
        {
            var response = new ServiceResponse<List<Vehicle>>
            {
                Data = await _dbContext.Vehicles.ToListAsync()
            };
            
            if (response.Data != null)
            {
                response.Message = "None vehicles avalible";
            }
            
            return response;

        }
    }
}
