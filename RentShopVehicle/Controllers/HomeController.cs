using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentShopVehicle.Domain.Entities.Car;
using RentShopVehicle.BusinessLogic;
using RentShopVehicle.Domain.Entities.Announcement;

namespace RentShopVehicle.Controllers
{
    public class HomeController : BaseController
    {

        IDeals deals;
        public HomeController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            deals = bl.getDealsS();
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
        public ActionResult Cars(FilterDataM filterM)
        {
            FilterData filterD=null;
            if (filterM != null) {
                filterD = new FilterData()
                {
                    Make = filterM.Make,
                    Model = filterM.Model,
                    Transmission = filterM.Transmission,
                };
                if (filterM.Price != null)
                {
                    var MinMax = Helpers.SParseMinMax(filterM.Price);
                    filterD.min = MinMax.Item1;
                    filterD.max = MinMax.Item2;
                }
            }
            AnnouncementsMinInfo minInfo = new AnnouncementsMinInfo();

            minInfo.Announcements = deals.getAnnouncementByFilter(filterD);

            return View(minInfo);
        }

        [HttpPost]
        public ActionResult FindCar(FilterDataM filterM)
        {
            return RedirectToAction("Cars", "Home", filterM);
        }

        [HttpGet]
        public ActionResult Contacts()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CarDetails(int Id)
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            AnnouncementDetInfo detInfoM = null;
            AnnouncementDetInfoD detInfoD = deals.getCarDetailById(Id);
            detInfoM = new AnnouncementDetInfo()
            {
                Id = detInfoD.Id,
                Make = detInfoD.Make,
                Model = detInfoD.Model,
                Year = detInfoD.Year,
                HP = detInfoD.HP,
                VIN = detInfoD.VIN,
                Transmission = detInfoD.Transmission,
                Mileage = detInfoD.Mileage,
                Color = detInfoD.Color,
                Price = detInfoD.Price,
                ImageUrls = new List<string>(),
            };

            for (int i = 0; i < detInfoD.Images.Count; i++)
            {
                detInfoM.ImageUrls.Add(
                        $"data:image;base64,{Convert.ToBase64String(detInfoD.Images[i])}"
                    );
            }

            return View(detInfoM);
        }
    }
}