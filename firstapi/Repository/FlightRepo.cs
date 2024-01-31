using firstapi.Models;
namespace firstapi.Repository
{
    public class FlightRepo : IFlight<PriyankaFlight>
    {
        private readonly Ace52024Context db;
        public FlightRepo() {}

        public FlightRepo(Ace52024Context _db)
        {
            db = _db;
        }

        public void AddFlight(PriyankaFlight f)
        {
            db.PriyankaFlights.Add(f);
            db.SaveChanges();
        }

        public void DeleteFlight(int id)
        {
            PriyankaFlight f = db.PriyankaFlights.Find(id);
            db.PriyankaFlights.Remove(f);
            db.SaveChanges();
        }

        public List<PriyankaFlight> GetAllFlights()
        {
            return db.PriyankaFlights.ToList();
        }

        public PriyankaFlight GetFlightById(int id)
        {
            return db.PriyankaFlights.Find(id);
        }

        public void UpdateFlight(int id, PriyankaFlight f)
        {
            db.PriyankaFlights.Update(f);
            db.SaveChanges();
        }
    }
}