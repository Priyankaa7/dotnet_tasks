using firstapi.Models;
using firstapi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace firstapi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightServ<PriyankaFlight> _flightServ;

        public FlightController(IFlightServ<PriyankaFlight> flightServ)
        {
            _flightServ = flightServ;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriyankaFlight>>> GetFlights()
        {
            return _flightServ.GetAllFlights();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PriyankaFlight>> GetFlight(int id)
        {
            var flight = _flightServ.GetFlightById(id);
            if (flight == null)
            {
                return NotFound();
            }
            return flight;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlight(int id, PriyankaFlight flight)
        {
            if (id != flight.FlightId)
            {
                return BadRequest();
            }
            try
            {
                _flightServ.UpdateFlight(id, flight);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriyankaFlightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<PriyankaFlight>> PostFlight(PriyankaFlight flight)
        {
            try
            {
                _flightServ.AddFlight(flight);
            }
            catch(DbUpdateException)
            {
                if (PriyankaFlightExists(flight.FlightId))
                {
                    return Conflict();
                }
                else 
                {
                    throw;
                }
            }
            return CreatedAtAction("GetFlight", new { id = flight.FlightId }, flight);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var flight = _flightServ.GetFlightById(id);
            if (flight == null)
            {
                return NotFound();
            }
            _flightServ.DeleteFlight(id);
            return NoContent();
        }

        private bool PriyankaFlightExists(int id)
        {
            PriyankaFlight f = _flightServ.GetFlightById(id);
            if (f != null)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }        
    }
}