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

        public async Task<ServiceResponse<List<VehicleGet>>> GetVehiclesAsync()
        {


            var response = new ServiceResponse<List<VehicleGet>>
            {
                Data = await _dbContext.Vehicles.
                Select(e =>
                    new VehicleGet
                    {
                        Id = e.IdVehicle,
                        Manufacturer = e.Manufacturer,
                        Model = e.Model,
                        ProductionStart = e.ProductionStart,
                        ProductionEnd = e.ProductionEnd,
                        VehicleNotes = e.VehicleNotes
                    })
                .ToListAsync()
            };

            if (response.Data == null)
            {
                response.Message = "No vehicles avalible";
            }

            return response;

        }
    }
}
