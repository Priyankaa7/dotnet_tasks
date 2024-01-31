using firstapi.Models;
namespace firstapi.Repository
{
    public interface IFlight<PriyankaFlight>
    {
        List<PriyankaFlight> GetAllFlights();
        void AddFlight(PriyankaFlight f);
        void UpdateFlight(int id, PriyankaFlight f);
        PriyankaFlight GetFlightById(int id);
        void DeleteFlight(int id);
    }
}