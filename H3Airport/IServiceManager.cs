using H3Airport.Models;

namespace H3Airport
{
    public interface IServiceManager
    {
        Task<Airline> GetAirline(int id);
        Task<List<Airline>> GetAirlines();
        Task<Airport> GetAirport(string iata);
        Task<List<Airport>> GetAirports();
        Task<List<Flight>> GetAllFlights();
        Task<Flight> GetFlight(int id);
    }
}