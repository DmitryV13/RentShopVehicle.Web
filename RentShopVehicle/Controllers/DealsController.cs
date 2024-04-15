using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentShopVehicle.Models;
using RentShopVehicle.Domain.Entities.Announcement;
using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.Domain.Entities.User;

namespace RentShopVehicle.Controllers
{
    public class DealsController : BaseController
    {

        protected readonly IDeals deals;

        public DealsController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            deals = bl.getDealsS();
        }

        [HttpGet]
        public ActionResult Announcements()
        {
            AllAnnouncements allAnnouncements = new AllAnnouncements() {
                AnnouncementConnectors = deals.GetAnnouncementConnectorsByUserId((System.Web.HttpContext.Current.Session["SessionUser"] as UserMinData).Id),
            };
            return View(allAnnouncements);
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
                UserCookies=getCookiesString(),
            };
            deals.CreateAnnouncement(announcementD);
            return RedirectToAction("Announcements", "Deals");
        }
    }
}