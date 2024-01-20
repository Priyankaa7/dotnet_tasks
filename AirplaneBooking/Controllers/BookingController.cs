using AirplaneBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneBooking.Controllers;
public class BookingController : Controller
{
    private readonly Ace52024Context db;

    public BookingController(Ace52024Context _db)
    {
        db = _db;     
    }
    public IActionResult ShowBookings()
    {
        ViewBag.username = HttpContext.Session.GetString("uname");
        return View(db.PriyankaBookings);
    }

    [HttpGet]
    public IActionResult AddBooking()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddBooking(PriyankaBooking b)
    {
        db.PriyankaBookings.Add(b);
        db.SaveChanges();
        return RedirectToAction("ShowBookings");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        PriyankaBooking b = db.PriyankaBookings.Where(x => x.BookingId == id).FirstOrDefault();
        return View(b);
    }
    [HttpPost]
    public IActionResult Edit(PriyankaBooking b)
    {
        db.PriyankaBookings.Update(b);
        db.SaveChanges();
        return RedirectToAction("ShowBookings");
    }
    public IActionResult Details(int id)
    {
        PriyankaBooking b = db.PriyankaBookings.Where(x => x.BookingId == id).FirstOrDefault();
        return View(b);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        PriyankaBooking b = db.PriyankaBookings.Where(x => x.BookingId == id).FirstOrDefault();
        return View(b);        
    }
    [HttpPost]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        PriyankaBooking b = db.PriyankaBookings.Where(x => x.BookingId == id).FirstOrDefault();
        db.PriyankaBookings.Remove(b);
        db.SaveChanges();
        return RedirectToAction("ShowBookings");
    }
}