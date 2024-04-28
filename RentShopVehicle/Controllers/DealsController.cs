using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentShopVehicle.Models;
using RentShopVehicle.Domain.Entities.Announcement;
using RentShopVehicle.Domain.Entities.User;
using RentShopVehicle.Domain.Entities.Car;
using RentShopVehicle.BusinessLogic.Interfaces;
using System.IO;
using System.Web.Http.Results;

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
            AllAnnouncements allAnnouncements = new AllAnnouncements()
            {
                AnnouncementConnectors = deals.GetAnnouncementConnectorsByUserId((System.Web.HttpContext.Current.Session["SessionUser"] as UserMinData).Id),
            };
            return View(allAnnouncements);
        }

        [HttpGet]
        public ActionResult Purchases()
        {
            AllAnnouncements allAnnouncements = new AllAnnouncements()
            {
                AnnouncementConnectors = deals.GetAnnouncementConnectorsByUserId((System.Web.HttpContext.Current.Session["SessionUser"] as UserMinData).Id),
            };
            return View(allAnnouncements);
        }

        [HttpPost]
        public ActionResult CreateAnnouncement(AnnouncementDetInfo announcementM)
        {
            AnnouncementDetInfoD announcementD = new AnnouncementDetInfoD()
            {
                HP = announcementM.HP,
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
                RentTimeInDays=announcementM.RentTimeInDays,
            };
            deals.CreateAnnouncement(announcementD);
            return RedirectToAction("Announcements", "Deals");
        }

        [HttpPost]
        public ActionResult AddAnnouncementPhotos(AddPhotosModel photodM)
        {
            AddPhotosData photosD = new AddPhotosData()
            {
                AnnouncementId = photodM.AnnouncementId,
                Images = new List<byte[]>(),
            };
            

            for (int i = 0; i < photodM.Images.Count; i++)
            {
                using (var binaryReader = new BinaryReader(photodM.Images[i].InputStream))
                {
                photosD.Images.Add(binaryReader.ReadBytes(photodM.Images[i].ContentLength));

                }
            }

            var response = deals.AddPhotos(photosD);
            if(!response)
                return RedirectToAction("E500", "Error");
            return RedirectToAction("Announcements", "Deals");
        }

        [HttpGet]
        public ActionResult AnnouncementMoreInfo(int Id)
        {

            AnnouncementDetInfoD detInfoD = deals.getAnnouncementDetInfoById(Id);
            if (detInfoD==null)
                return RedirectToAction("E404", "Error");
            AnnouncementDetInfo detInfoM = new AnnouncementDetInfo()
            {
                HP = detInfoD.HP,
                Color = detInfoD.Color,
                Make = detInfoD.Make,
                Mileage = detInfoD.Mileage,
                Model = detInfoD.Model,
                Year = detInfoD.Year,
                Id = detInfoD.Id,
                VIN = detInfoD.VIN,
                Transmission = detInfoD.Transmission,
                Price = detInfoD.Price,
                RentTimeInDays = detInfoD.RentTimeInDays,
                Type = detInfoD.Type,
                ImageUrls = detInfoD.ImageUrls,
            };
            return View(detInfoM);
        }

        [HttpGet]
        public ActionResult DeleteAnnouncement(int Id)
        {
            var response = deals.DeleteAnnouncementById(Id);
            
            return RedirectToAction("Announcements", "Deals");
        }

        [HttpGet]
        public ActionResult MakePurchase(int Id)
        {
            var response = deals.MakePurchase(Id);

            return RedirectToAction("Cars", "Home");
        }
    }
}