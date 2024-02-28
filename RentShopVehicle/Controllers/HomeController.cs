using RentShopVehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentShopVehicle.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AboutUs()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Blog()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cars()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contacts()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(string name, string email, int age)
        {
            return RedirectToAction("Contacts", "Home");
        }
    }
}