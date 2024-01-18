using AirplaneBooking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneBooking.Controllers
{
    public class FlightController : Controller
    {
        public static Ace52024Context db;

        public FlightController(Ace52024Context _db)
        {
            db = _db;
        }

        public ActionResult ShowFlights()
        {
            return View(db.PriyankaFlights);
        }
    }
}