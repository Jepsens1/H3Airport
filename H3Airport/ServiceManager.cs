using H3Airport.Handler;
using H3Airport.Models;
using Microsoft.EntityFrameworkCore;

namespace H3Airport
{
    public class ServiceManager : IServiceManager
    {
        private IHandle _handle;

        public ServiceManager(IHandle handle)
        {
            _handle = handle;
        }
        public async Task<List<Flight>> GetAllFlights()
        {
            return await _handle.GetAllFlights();
        }
        public async Task<Flight> GetFlight(int id)
        {
            return await _handle.GetFlight(id);
        }
        public async Task<List<Airline>> GetAirlines()
        {
            return await _handle.GetAirlines();
        }
        public async Task<Airline> GetAirline(int id)
        {
            return await _handle.GetAirline(id);
        }
        public async Task<Airport> GetAirport(string iata)
        {
            return await _handle.GetAirport(iata);
        }
        public async Task<List<Airport>> GetAirports()
        {
            return await _handle.GetAirports();
        }

    }
}
