using MAS_PROJ.Server.Data;
using MAS_PROJ.Shared.Models;
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

        public async Task<ServiceResponse<VehicleGet>> GetVehicleByIdAsync(int IdVehicle)
        {
            var response = new ServiceResponse<VehicleGet>();
            var vehicleExists = await _dbContext.Vehicles.AnyAsync(e => e.IdVehicle == IdVehicle);

            if (!vehicleExists)
            {
                response.Success = false;
                response.Message = "Vehicle with this ID does not exist";
            }
            else
            {
                var vehicle = await _dbContext.Vehicles.AsNoTracking()
                    .Where(e => e.IdVehicle == IdVehicle)
                    .Select(e => new VehicleGet
                    {
                        Id = e.IdVehicle,
                        Manufacturer = e.Manufacturer,
                        Model = e.Model,
                        ProductionStart = e.ProductionStart,
                        ProductionEnd = e.ProductionEnd,
                        VehicleNotes = e.VehicleNotes
                    }).FirstOrDefaultAsync();
                response.Data = vehicle;
            }

            return response;


        }

        public async Task<ServiceResponse<VehicleDetailsGet>> GetVehicleDetailsByIdAsync(int IdVehicle)
        {
            var response = new ServiceResponse<VehicleDetailsGet>();
            var vehicleExists = await _dbContext.Vehicles.AnyAsync(e => e.IdVehicle == IdVehicle);

            if (!vehicleExists) { 
                response.Success = false;
                response.Message = "Vehicle with this ID does not exist";
            }
            else
            {
                var waterSubTypes = await _dbContext.WaterVehicles.AsNoTracking()
                    .Where(e => e.IdVehicle == IdVehicle)
                    .Select(e => new VehicleSubTypeGet {
                        IdSubtype = e.IdSubtype,
                        Name = e.Name,
                        SubtypeNotes = e.SubtypeNotes,
                        SubType = SubType.Water,
                        FuelSpecifics = e.FuelSpecifics,
                        PurposeSpecifics = e.PurposeSpecifics,
                        MinCrew = e.MinCrew
                    })
                    .ToListAsync();

                var landSubTypes = await _dbContext.LandVehicles.AsNoTracking()
                    .Where(e => e.IdVehicle == IdVehicle)
                    .Select(e => new VehicleSubTypeGet
                    {
                        IdSubtype = e.IdSubtype,
                        Name = e.Name,
                        SubtypeNotes = e.SubtypeNotes,
                        SubType = SubType.Land,
                        FuelSpecifics = e.FuelSpecifics,
                        PoiseSpecifics = e.PoiseSpecifics,
                        EnginePower = e.EnginePower,
                        EngineTorque = e.EngineTorque
                    })
                    .ToListAsync();
                var allSubtypes = waterSubTypes.Concat(landSubTypes).ToList();

                var vehicle = await _dbContext.Vehicles.AsNoTracking()
                    .Where(e => e.IdVehicle == IdVehicle)
                    .Select(e => new VehicleDetailsGet
                    {
                        IdVehicle = e.IdVehicle,
                        Manufacturer = e.Manufacturer,
                        Model = e.Model,
                        ProductionStart = e.ProductionStart,
                        ProductionEnd = e.ProductionEnd,
                        VehicleNotes = e.VehicleNotes,
                        VehicleSubType = allSubtypes
                    }).FirstOrDefaultAsync();
                response.Data = vehicle;
            }

            return response;


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
