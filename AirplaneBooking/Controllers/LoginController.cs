using AirplaneBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneBooking.Controllers;

public class LoginController : Controller
{
    private readonly Ace52024Context db;
    private readonly ISession session;

    public LoginController(Ace52024Context _db, IHttpContextAccessor httpContextAccessor)
    {
        db = _db;
        session = httpContextAccessor.HttpContext.Session;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Register(UserTable user)
    {
        db.UserTables.Add(user);
        db.SaveChanges();
        return View("Login");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(UserTable u)
    {
        var result = (from i in db.UserTables
                        where i.Email==u.Email && i.Password==u.Password
                        select i).SingleOrDefault();

        if (result != null)
        {
            HttpContext.Session.SetString("uname", result.Name.ToString());
            return RedirectToAction("Index", "Home");
        }
        else 
        {
            return View();
        }
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
