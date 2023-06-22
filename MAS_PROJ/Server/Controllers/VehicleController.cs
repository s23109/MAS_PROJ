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

        [HttpGet("Details/{IdVehicle}")]
        public async Task<ActionResult<ServiceResponse<VehicleDetailsGet>>> GetVehicleDetailsById(int IdVehicle)
        {
            var result = await _vehicleService.GetVehicleDetailsByIdAsync(IdVehicle);

            if (result.Data != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }

        }

        [HttpPost("CreateNew")]
        public async Task<ActionResult<VehiclePost>> CreateNewVehicle([FromBody]VehiclePost vehicle)
        {
            var result = await _vehicleService.CreateVehicleAsync(vehicle);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }


        [HttpPost("Create/{Id}")]
        public async Task<ActionResult<VehiclePost>> AddSubtypeToExisting([FromBody] VehiclePost vehicle,int Id)
        {
            var result = await _vehicleService.AddVehicleSubTypeAsync(vehicle, Id);

            if (!result.Success)
            {
                return BadRequest(result);
            }else
            {
                return Ok(result);
            }
        }
    }
}
