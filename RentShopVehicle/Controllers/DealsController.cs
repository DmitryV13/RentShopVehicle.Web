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
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using RentShopVehicle.Domain.Enums;

namespace RentShopVehicle.Controllers
{
    public class DealsController : BaseController
    {

        protected readonly IDeals deals;
        private readonly IEmailSender emailSender;

        public DealsController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            deals = bl.getDealsS();
            emailSender = bl.GetEmailSenderS();
        }

        [HttpGet]
        public ActionResult Announcements()
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            AllAnnouncements allAnnouncements = new AllAnnouncements() {
                AnnouncementConnectors = deals.GetAnnouncementConnectorsByUserId((System.Web.HttpContext.Current.Session["SessionUser"] as UserMinData).Id),
            };
            return View(allAnnouncements);
        }

        [HttpGet]
        public ActionResult Sales()
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");

            }
            AllAnnouncements allAnnouncements = new AllAnnouncements()
            {
                AnnouncementConnectors = deals.GetAnnouncementConnectorsByUserId((System.Web.HttpContext.Current.Session["SessionUser"] as UserMinData).Id),
            };
            return View(allAnnouncements);
        }

        [HttpGet]
        public ActionResult Purchases()
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            AllAnnouncements allAnnouncements = new AllAnnouncements()
            {
                AnnouncementConnectors = deals.GetAnnouncementConnectorsByUserId((System.Web.HttpContext.Current.Session["SessionUser"] as UserMinData).Id),
            };
            return View(allAnnouncements);
        }

        [HttpPost]
        public ActionResult CreateAnnouncement(AnnouncementDetInfo announcementM)
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

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
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

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
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

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
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            var response = deals.DeleteAnnouncementById(Id);
            
            return RedirectToAction("Announcements", "Deals");
        }

        [HttpPost]
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> MakePurchase(DeliveryM deliveryM)
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            var user = (HttpContext.Session["SessionUser"] as UserMinData);
            var responce = deals.MakePurchase(deliveryM.Id);
            if (responce && deliveryM.DeliveryType == DeliveryType.FromOwner)
            {
                var userM = session.GetUserById(user.Id);
                var reciever = userM.Email;
                var subject = "Notification";
                var message = "Purchase was done"+"address .....";

                await emailSender.SendEmailAsync(reciever, subject, message);
            }

            return (Microsoft.AspNetCore.Mvc.IActionResult)RedirectToAction("Cars", "Home");
        }

    }
}