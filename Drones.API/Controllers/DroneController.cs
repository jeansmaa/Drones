using Drones.Core.Models;
using Microsoft.AspNetCore.Mvc;



namespace Drones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DroneController : Controller
    {
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Drones.Core.Models.Drone>>> Get()
        {
            try
            {
                List<Drones.Core.Models.Drone> result = new List<Core.Models.Drone>();
                result.Add(new Core.Models.Drone { Model = Model.Cruiserweight, State = State.LOADING, SerialNumber = "545878787SD" });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Drones.Core.Models.Drone drone)
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
