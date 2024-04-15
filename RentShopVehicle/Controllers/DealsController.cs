using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentShopVehicle.Models;
using RentShopVehicle.Domain.Entities.Announcement;

namespace RentShopVehicle.Controllers
{
    public class DealsController : BaseController
    {
        [HttpGet]
        public ActionResult Announcements()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Sales()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Purchases()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAnnouncement(CreateAnnouncementM announcementM)
        {
            CreateAnnouncementD announcementD = new CreateAnnouncementD()
            {
                Make = announcementM.Make,
                Model = announcementM.Model,
                Year = announcementM.Year,
                Color = announcementM.Color,
                VIN = announcementM.VIN,
                Mileage = announcementM.Mileage,
                Transmission = announcementM.Transmission,
                Type = announcementM.Type,
                Price = announcementM.Price,
            };
            return RedirectToAction("Announcements", "Deals");
        }
    }
}