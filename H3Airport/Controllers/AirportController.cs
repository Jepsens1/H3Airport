using H3Airport.Handler;
using H3Airport.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace H3Airport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private AirportHandler _handler;

        public AirportController(AirportHandler handler)
        {
            _handler = handler;
        }

        [Route("[Action]")]
        [HttpGet]
        public async Task<ActionResult<List<Flight>>> GetFlights()
        {
            var flights = await _handler.GetAllFlights();
            if(flights == null)
            {
                return Problem();
            }
            return Ok(flights);
        }
        [Route("[Action]")]
        [HttpGet]
        public async Task<ActionResult<Flight>> GetFlight(int id)
        {
            var flight = await _handler.GetFlight(id);
            if (flight == null)
            {
                return Problem();
            }
            return Ok(flight);
        }
        [Route("[Action]")]
        [HttpGet]
        public async Task<ActionResult<Airline>> GetAirline(int id)
        {
            var airline = await _handler.GetAirline(id);
            if (airline == null)
            {
                return Problem();
            }
            return Ok(airline);
        }
        [Route("[Action]")]
        [HttpGet]
        public async Task<ActionResult<List<Airline>>> GetAirlines()
        {
            var airlines = await _handler.GetAirlines();
            if (airlines == null)
            {
                return Problem();
            }
            return Ok(airlines);
        }
        [Route("[Action]")]
        [HttpGet]
        public async Task<ActionResult<Airport>> GetAirport(string iata)
        {
            var airport = await _handler.GetAirport(iata);
            if (airport == null)
            {
                return Problem();
            }
            return Ok(airport);
        }
        [Route("[Action]")]
        [HttpGet]
        public async Task<ActionResult<List<Airport>>> GetAirports()
        {
            var airports = await _handler.GetAirports();
            if (airports == null)
            {
                return Problem();
            }
            return Ok(airports);
        }



    }
}
