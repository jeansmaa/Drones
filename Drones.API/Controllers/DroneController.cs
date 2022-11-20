using Drones.Core.Models;
using Drones.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Drones.Infrastructure.Interfaces;
using Drones.Infrastructure.Persistence;

namespace Drones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DroneController : Controller
    {
        readonly IFleetControl fleet;
        public DroneController(IFleetControl fleet)
        {
            this.fleet = fleet;
        }

        [HttpGet]
        [Route("GetFleet")]
        public async Task<ActionResult<IEnumerable<Drone>>> GetFleet()
        {
            try
            {
                return Ok(this.fleet.GetFleet());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("GetDroneById/{id}")]
        public async Task<ActionResult<Drone>> GetDroneById(int id)
        {
            try
            {
                return Ok(this.fleet.GetDroneById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpGet]
        [Route("LoadedMedication/{id}")]
        public async Task<ActionResult<Drone>> CheckingLoadedMedication(int id)
        {
            try
            {
                return Ok(this.fleet.CheckingLoadedMedication(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpGet]
        [Route("BatteryLevel/{id}")]
        public async Task<ActionResult<Drone>> DroneBatteryLevel(int id)
        {
            try
            {
                return Ok(this.fleet.DroneBatteryLevel(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpGet]
        [Route("DronesForLoading")]
        public async Task<ActionResult<IEnumerable<Drone>>> CheckingAvailableDronesForLoading()
        {
            try
            {
                return Ok(this.fleet.CheckingAvailableDronesForLoading());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpPost]
        [Route("RegisteringDrone")]
        public async Task<IActionResult> RegisteringDrone([FromBody] Drone drone)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await this.fleet.RegisteringDrone(drone);
                    return Ok();
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPatch]
        [Route("LoadingDrone/{id}")]
        public async Task<IActionResult> LoadingDrone(int id,[FromBody] List<Medication> medications)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MedicationCodeAllowed medicationCodeAllowed = new MedicationCodeAllowed();
                    MedicationNameAllowed medicationNameAllowed = new MedicationNameAllowed();
                    foreach (Medication medic in medications)
                    {
                        if (!medicationCodeAllowed.Allowed(medic.Code) ||
                            !medicationNameAllowed.Allowed(medic.Name))
                        {
                            return BadRequest("Error in name or code");
                        }
                    }
                    await this.fleet.LoadingDrone(id, medications);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }
    }
}
