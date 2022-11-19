using Drones.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Drones.Infrastructure.Persistence;


namespace Drones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DroneController : Controller
    {
        FleetControl fleet=new FleetControl();
        [HttpGet]        
        public async Task<ActionResult<IEnumerable<Drone>>> Get()
        {
            try
            {
                return Ok(this.fleet.airport.Fleet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("{id}")]
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Drone drone)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //await _mediator.Send(new ProducerCustomerCommand(customer));
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
