using H3Airport.Models;
using Microsoft.EntityFrameworkCore;

namespace H3Airport.Handler
{
    public class AirportHandler : IHandle
    {
        private H3airportContext _context;

        public AirportHandler()
        {
            _context = new H3airportContext();
        }

        public async Task<List<Flight>> GetAllFlights()
        {
            var flights = await _context.Flights.ToListAsync();
            if (flights == null)
            {
                return null;
            }
            return flights;
        }
        public async Task<Flight> GetFlight(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return null;
            }
            return flight;
        }
        public async Task<List<Airline>> GetAirlines()
        {
            var airlines = await _context.Airlines.Include(f => f.Flights).ToListAsync();
            if (airlines == null)
            {
                return null;
            }
            return airlines;
        }
        public async Task<Airline> GetAirline(int id)
        {
            var airline = await _context.Airlines.Include(f => f.Flights).Where(i => i.Id == id).FirstOrDefaultAsync();
            if (airline == null)
            {
                return null;
            }
            return airline;
        }
        public async Task<Airport> GetAirport(string iata)
        {
            var airport = await _context.Airports.Include(f => f.FlightDeparturelocationNavigations).Include(f => f.FlightDestinationNavigations)
                .Where(i => i.IataCode == iata.ToUpper()).FirstOrDefaultAsync();
            if (airport == null)
            {
                return null;
            }
            return airport;
        }
        public async Task<List<Airport>> GetAirports()
        {
            var airports = await _context.Airports.ToListAsync();
            if (airports == null)
            {
                return null;
            }
            return airports;
        }

    }
}
