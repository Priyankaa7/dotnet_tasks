using AirplaneBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneBooking.Controllers;
public class FlightController : Controller
{
    private readonly Ace52024Context db;

    public FlightController(Ace52024Context _db)
    {
        db = _db;     
    }
    public IActionResult ShowFlights()
    {
        ViewBag.Name = HttpContext.Session.GetString("uname");
        return View(db.PriyankaFlights);
    }

    [HttpGet]
    public IActionResult AddFlight()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddFlight(PriyankaFlight f)
    {
        db.PriyankaFlights.Add(f);
        db.SaveChanges();
        return RedirectToAction("ShowFlights");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        PriyankaFlight f = db.PriyankaFlights.Where(x => x.FlightId == id).FirstOrDefault();
        return View(f);
    }
    [HttpPost]
    public IActionResult Edit(PriyankaFlight f)
    {
        db.PriyankaFlights.Update(f);
        db.SaveChanges();
        return RedirectToAction("ShowFlights");
    }
    public IActionResult Details(int id)
    {
        PriyankaFlight f = db.PriyankaFlights.Where(x => x.FlightId == id).FirstOrDefault();
        return View(f);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        PriyankaFlight f = db.PriyankaFlights.Where(x => x.FlightId == id).FirstOrDefault();
        return View(f);        
    }
    [HttpPost]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        PriyankaFlight f = db.PriyankaFlights.Where(x => x.FlightId == id).FirstOrDefault();
        db.PriyankaFlights.Remove(f);
        db.SaveChanges();
        return RedirectToAction("ShowFlights");
    }
}