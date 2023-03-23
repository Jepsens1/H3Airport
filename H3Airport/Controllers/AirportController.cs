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
        private ServiceManager _manager;

        public AirportController()
        {
            _manager = new ServiceManager(new AirportHandler());
        }

        [Route("[Action]")]
        [HttpGet]
        public async Task<ActionResult<List<Flight>>> GetFlights()
        {
            var flights = await _manager.GetAllFlights();
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
            var flight = await _manager.GetFlight(id);
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
            var airline = await _manager.GetAirline(id);
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
            var airlines = await _manager.GetAirlines();
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
            var airport = await _manager.GetAirport(iata);
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
            var airports = await _manager.GetAirports();
            if (airports == null)
            {
                return Problem();
            }
            return Ok(airports);
        }



    }
}
