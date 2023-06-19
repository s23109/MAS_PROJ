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

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<VehicleGet>>>> GetVehiclesAsync()
        {
            var result = await _vehicleService.GetVehiclesAsync();
            return Ok(result);
        }

        [HttpGet("{IdVehicle}")]
        public async Task<ActionResult<ServiceResponse<VehicleDetailsGet>>> GetVehicleById(int IdVehicle)
        {
            var result = await _vehicleService.GetVehicleByIdAsync(IdVehicle);

            if (result.Data != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
            
        }
    }
}
