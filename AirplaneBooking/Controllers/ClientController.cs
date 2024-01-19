using AirplaneBooking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneBooking.Controllers
{
    public class ClientController : Controller
    {
        public static Ace52024Context db;
        public ClientController(Ace52024Context _db)
        {
            db = _db;
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserTable u)
        {
            var result = (from i in db.UserTables
                            where i.Email==u.Email && i.Password==u.Password
                            select i).SingleOrDefault();
            if (result != null)
            {
                return RedirectToAction("ShowFlights", "Flight");
            }
            else {
                //@ViewBag["Sorry wrong credentials"];
                return View();
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserTable user)
        {
            db.UserTables.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login");
        }

    }
}