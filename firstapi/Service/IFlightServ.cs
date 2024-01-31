namespace firstapi.Service
{
    public interface IFlightServ<PriyankaFlight>
    {
        List<PriyankaFlight> GetAllFlights();
        void AddFlight(PriyankaFlight f);
        void UpdateFlight(int id, PriyankaFlight f);
        PriyankaFlight GetFlightById(int id);
        void DeleteFlight(int id);        
    }
}