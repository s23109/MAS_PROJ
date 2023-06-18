using MAS_PROJ.Server.Services.VehicleService;
using Microsoft.AspNetCore.Mvc;

namespace MAS_PROJ.Server.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }


    }
}
