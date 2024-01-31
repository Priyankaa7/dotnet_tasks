using firstapi.Models;
using firstapi.Repository;

namespace firstapi.Service
{
    public class FlightServ : IFlightServ<PriyankaFlight>
    {
        private readonly IFlight<PriyankaFlight> flight;
        public FlightServ(){}

        public FlightServ(IFlight<PriyankaFlight> _flight)
        {
            flight = _flight;
        }
        public void AddFlight(PriyankaFlight f)
        {
            flight.AddFlight(f);
        }

        public void DeleteFlight(int id)
        {
            flight.DeleteFlight(id);
        }

        public List<PriyankaFlight> GetAllFlights()
        {
            return flight.GetAllFlights();
        }

        public PriyankaFlight GetFlightById(int id)
        {
            return flight.GetFlightById(id);
        }

        public void UpdateFlight(int id, PriyankaFlight f)
        {
            flight.UpdateFlight(id, f);
        }
    }
}