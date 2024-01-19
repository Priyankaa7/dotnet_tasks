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
        public IActionResult ShowFlights()
        {
            return View(db.PriyankaFlights);
        }

        [HttpGet]
        public ActionResult BookFlight()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BookFlight(PriyankaFlight f)
        {
            db.PriyankaFlights.Add(f);
            db.SaveChanges();
            return RedirectToAction("ShowFlights");
        }

        public ActionResult Details(int id)
        {
            PriyankaFlight f = db.PriyankaFlights.Where(x => x.FlightId == id).FirstOrDefault();
            return View(f);
        }

        public ActionResult Edit(int id)
        {
            PriyankaFlight f = db.PriyankaFlights.Where(x => x.FlightId == id).FirstOrDefault();
            return View(f);            
        }
        [HttpPost]
        public ActionResult Edit(PriyankaFlight f)
        {
            db.PriyankaFlights.Update(f);
            db.SaveChanges();
            return RedirectToAction("ShowFlights");
        }

        public ActionResult Delete(int id)
        {
            PriyankaFlight f = db.PriyankaFlights.Where(x => x.FlightId == id).FirstOrDefault();
            return View(f);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PriyankaFlight f = db.PriyankaFlights.Where(x => x.FlightId == id).FirstOrDefault();
            db.PriyankaFlights.Remove(f);
            db.SaveChanges();
            return RedirectToAction("ShowFlights");
        }
    }
}