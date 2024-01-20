using AirplaneBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneBooking.Controllers;
public class CustomerController : Controller
{
    private readonly Ace52024Context db;

    public CustomerController(Ace52024Context _db)
    {
        db = _db;     
    }
    public IActionResult ShowCustomers()
    {
        ViewBag.uName = HttpContext.Session.GetString("uname");
        return View(db.PriyankaCustomers);
    }

    [HttpGet]
    public IActionResult AddCustomer()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddCustomer(PriyankaCustomer c)
    {
        db.PriyankaCustomers.Add(c);
        db.SaveChanges();
        return RedirectToAction("ShowCustomers");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        PriyankaCustomer c = db.PriyankaCustomers.Where(x => x.CustomerId == id).FirstOrDefault();
        return View(c);
    }
    [HttpPost]
    public IActionResult Edit(PriyankaCustomer c)
    {
        db.PriyankaCustomers.Update(c);
        db.SaveChanges();
        return RedirectToAction("ShowCustomers");
    }
    public IActionResult Details(int id)
    {
        PriyankaCustomer c = db.PriyankaCustomers.Where(x => x.CustomerId == id).FirstOrDefault();
        return View(c);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        PriyankaCustomer c = db.PriyankaCustomers.Where(x => x.CustomerId == id).FirstOrDefault();
        return View(c);        
    }
    [HttpPost]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        PriyankaCustomer c = db.PriyankaCustomers.Where(x => x.CustomerId == id).FirstOrDefault();
        db.PriyankaCustomers.Remove(c);
        db.SaveChanges();
        return RedirectToAction("ShowCustomers");
    }
}