using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentShopVehicle.BusinessLogic;
using RentShopVehicle.Domain.Entities.Car;

namespace RentShopVehicle.Controllers
{
    public class HomeController : Controller
    {

        public ICar carService;


        //SessionStatus();
        //if ((string) System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
        //{
        //    return RedirectToAction("Index", "Login");
        //}

    public HomeController()
        {
            var tmp = new BusinessLogic.BusinessLogic();
            carService = tmp.getCarS();
        }
        
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

        [HttpPost]
        public ActionResult FindCar(Car newCar)
        {
            var carDomain = new CarD()
            {
                Price = newCar.Price
            };
            ResponceFindCar resp = carService.FindCar(carDomain);
            if (resp.Found == true)
            {

            }
            return RedirectToAction("Contacts", "Home");
        }
    }
}