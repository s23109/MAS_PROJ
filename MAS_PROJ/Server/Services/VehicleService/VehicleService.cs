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

        public async Task<ServiceResponse<VehiclePost>> AddVehicleSubTypeAsync(VehiclePost newVehicle, int VehicleId)
        {
            var response = new ServiceResponse<VehiclePost>();

            if (!(await _dbContext.Vehicles.AnyAsync(e => e.IdVehicle == VehicleId)))
            {
                //vehicle does not exist
                response.Success = false;
                response.Message = "Vehicle with this ID does not exist";
                return response;
            }
            else
            {
                //vehicle exists

                if (newVehicle.SubType == SubType.Land)
                {
                    var subType = new LandVehicle
                    {
                        IdVehicle = VehicleId,
                        Name = newVehicle.Name,
                        SubtypeNotes = newVehicle.SubtypeNotes,
                        EnginePower = newVehicle.EnginePower,
                        EngineTorque = newVehicle.EngineTorque,
                        FuelSpecifics = createFuelFromVehiclePost(newVehicle),
                        PoiseSpecifics = createPoiseFromVehiclePost(newVehicle)
                    };

                    _dbContext.LandVehicles.Add(subType);
                    await _dbContext.SaveChangesAsync();

                    response.Success = true;
                    response.Data = newVehicle;
                }
                else if (newVehicle.SubType == SubType.Water)
                {
                    var subType = new WaterVehicle
                    {
                        IdVehicle = VehicleId,
                        Name = newVehicle.Name,
                        SubtypeNotes = newVehicle.SubtypeNotes,
                        MinCrew = newVehicle.MinCrew,
                        FuelSpecifics = createFuelFromVehiclePost(newVehicle),
                        PurposeSpecifics = createPurposeFromVehiclePost(newVehicle)
                    };

                    _dbContext.WaterVehicles.Add(subType);
                    await _dbContext.SaveChangesAsync();

                    response.Success = true;
                    response.Data = newVehicle;
                }

            }

            return response;
        }

        public async Task<ServiceResponse<VehiclePost>> CreateVehicleAsync(VehiclePost newVehicle)
        {
            var response = new ServiceResponse<VehiclePost>();


            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var vehicle = new Vehicle
                    {
                        Manufacturer = newVehicle.Manufacturer,
                        Model = newVehicle.Model,
                        ProductionStart = newVehicle.ProductionStart,
                        ProductionEnd = newVehicle.ProductionEnd,
                        VehicleNotes = newVehicle.VehicleNotes
                    };

                    _dbContext.Vehicles.Add(vehicle);
                    await _dbContext.SaveChangesAsync();
                    int newVehicleId = vehicle.IdVehicle;

                    if (newVehicle.SubType == SubType.Land)
                    {
                        var subType = new LandVehicle
                        {
                            IdVehicle = newVehicleId,
                            Name = newVehicle.Name,
                            SubtypeNotes = newVehicle.SubtypeNotes,
                            EnginePower = newVehicle.EnginePower,
                            EngineTorque = newVehicle.EngineTorque,
                            FuelSpecifics = createFuelFromVehiclePost(newVehicle),
                            PoiseSpecifics = createPoiseFromVehiclePost(newVehicle)
                        };

                        _dbContext.LandVehicles.Add(subType);
                        await _dbContext.SaveChangesAsync();

                        response.Success = true;
                        response.Data = newVehicle;
                    }
                    else if (newVehicle.SubType == SubType.Water)
                    {
                        var subType = new WaterVehicle
                        {
                            IdVehicle = newVehicleId,
                            Name = newVehicle.Name,
                            SubtypeNotes = newVehicle.SubtypeNotes,
                            MinCrew = newVehicle.MinCrew,
                            FuelSpecifics = createFuelFromVehiclePost(newVehicle),
                            PurposeSpecifics = createPurposeFromVehiclePost(newVehicle)
                        };

                        _dbContext.WaterVehicles.Add(subType);
                        await _dbContext.SaveChangesAsync();

                        response.Success = true;
                        response.Data = newVehicle;
                    }

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    response.Success = false;
                    response.Message = ex.Message;
                }
            }

            return response;
        }

        public FuelSpecifics createFuelFromVehiclePost(VehiclePost vehiclepost)
        {
            return new FuelSpecifics
            {
                FuelType = vehiclepost.FuelType,
                BatteryCapacity = vehiclepost.BatteryCapacity,
                BatteryType = vehiclepost.BatteryType,
                CombustionType = vehiclepost.CombustionType,
                FuelTypeDescription = vehiclepost.FuelTypeDescription,
                TankCapacity = vehiclepost.TankCapacity
            };
        }

        public PurposeSpecifics createPurposeFromVehiclePost(VehiclePost vehiclepost)
        {
            return new PurposeSpecifics
            {
                LoadType = vehiclepost.LoadType,
                MaxPassengers = vehiclepost.MaxPassengers,
                MinLifeBoats = vehiclepost.MinLifeBoats,
                PurposeType = vehiclepost.PurposeType,
                ShipCapacity = vehiclepost.ShipCapacity
            };
        }

        public PoiseSpecifics createPoiseFromVehiclePost(VehiclePost vehiclepost)
        {
            return new PoiseSpecifics
            {
                PoiseType = vehiclepost.PoiseType,
                TrackLength = vehiclepost.TrackLength,
                TrackWidth = vehiclepost.TrackWidth,
                WheelAmount = vehiclepost.WheelAmount,
                WheelWidth = vehiclepost.WheelWidth
            };
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

            if (!vehicleExists)
            {
                response.Success = false;
                response.Message = "Vehicle with this ID does not exist";
            }
            else
            {
                var vehicle = await _dbContext.Vehicles.Where(e => e.IdVehicle == IdVehicle)
                    .Include(e => e.VehicleSubTypeNavigation).FirstAsync();

                List<VehicleSubTypeGet> vehicleSubtypes = new List<VehicleSubTypeGet>();

                foreach (var vehicleSubType in vehicle.VehicleSubTypeNavigation)
                {

                    if (vehicleSubType is VehicleSubType)
                    {

                        if (vehicleSubType is LandVehicle)
                        {
                            var castVehicle = (LandVehicle)vehicleSubType;
                            vehicleSubtypes.Add(new VehicleSubTypeGet
                            {
                                EnginePower = castVehicle.EnginePower,
                                EngineTorque = castVehicle.EngineTorque,
                                FuelSpecifics = castVehicle.FuelSpecifics,
                                IdSubtype = castVehicle.IdSubtype,
                                Name = castVehicle.Name,
                                PoiseSpecifics = castVehicle.PoiseSpecifics,
                                SubtypeNotes = castVehicle.SubtypeNotes,
                                SubType = SubType.Land

                            });
                        }


                        if (vehicleSubType is WaterVehicle)
                        {
                            var castVehicle = (WaterVehicle)vehicleSubType;
                            vehicleSubtypes.Add(new VehicleSubTypeGet { 
                            MinCrew = castVehicle.MinCrew,
                            IdSubtype = castVehicle.IdSubtype,
                            FuelSpecifics = castVehicle.FuelSpecifics,
                            PurposeSpecifics = castVehicle.PurposeSpecifics,
                            Name = castVehicle.Name,
                            SubtypeNotes = castVehicle.SubtypeNotes,
                            SubType = SubType.Water
                            });

                        }
                    }

                }

                response.Data = new VehicleDetailsGet { 
                IdVehicle = vehicle.IdVehicle,
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,
                ProductionStart = vehicle.ProductionStart,
                ProductionEnd = vehicle.ProductionEnd,
                VehicleNotes = vehicle.VehicleNotes,
                VehicleSubType = vehicleSubtypes
                };


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
