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
using RentShopVehicle.Domain.Entities.Feedback;

namespace RentShopVehicle.Controllers
{
    public class HomeController : BaseController
    {

        IDeals deals;
        IBlog blog;
        public HomeController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            deals = bl.getDealsS();
            blog = bl.GetBlogS();
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
            BlogComments blogComments = new BlogComments()
            {
                Comments = new List<BlogComment>(),
            };
            var commentsD = blog.GetAllBlogComments();
            for(var i=0; i<commentsD.Count; i++)
            {
                var tmp = new BlogComment()
                {
                    MessageType = commentsD[i].MessageType,
                    Comment = commentsD[i].Comment,
                    UserName = commentsD[i].UserName,   
                };
                blogComments.Comments.Add(tmp); 
            }
            return View(blogComments);
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
            AllAnnouncementsDetInfo detInfoM = new AllAnnouncementsDetInfo()
            {
                Announcements = new List<AnnouncementDetInfo>(),
            };

            List<AnnouncementDetInfoD> detInfoD = deals.getAnnouncementByFilter(filterD);
            for (int i = 0; i < detInfoD.Count; i++)
            {
                var tmp = new AnnouncementDetInfo()
                {
                    Id = detInfoD[i].Id,
                    Make = detInfoD[i].Make,
                    Model = detInfoD[i].Model,
                    Year = detInfoD[i].Year,
                    HP = detInfoD[i].HP,
                    Transmission = detInfoD[i].Transmission,
                    Mileage = detInfoD[i].Mileage,
                    Price = detInfoD[i].Price,
                    ImageUrls = detInfoD[i].ImageUrls,
                };
                detInfoM.Announcements.Add(tmp);
            }

            return View(detInfoM);
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

        [HttpPost]
        public ActionResult AddBlogComment(BlogComment commentM)
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            BlogCommentD blogCommentD = new BlogCommentD()
            {
                MessageType = commentM.MessageType,
                Comment = commentM.Comment,
            };
            var result = blog.AddBlogComment(blogCommentD);
            return RedirectToAction("Blog", "Home");
        }

        [HttpPost]
        public ActionResult AddReview(BlogComment commentM)
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            BlogCommentD blogCommentD = new BlogCommentD()
            {
                AnnouncementId = commentM.AnnouncementId,
                MessageType = commentM.MessageType,
                Comment = commentM.Comment,
            };
            var result = blog.AddBlogComment(blogCommentD);

            return RedirectToAction("CarDetails", "Home", new { Id = commentM.AnnouncementId });
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
                ImageUrls = detInfoD.ImageUrls,
                BlogComments = new BlogComments(),
            };
            detInfoM.BlogComments.Comments = new List<BlogComment>();
            for (var i = 0; i < detInfoD.BlogComments.Count; i++)
            {
                var tmp = new BlogComment()
                {
                    MessageType = detInfoD.BlogComments[i].MessageType,
                    Comment = detInfoD.BlogComments[i].Comment,
                    UserName = detInfoD.BlogComments[i].UserName,
                };
                detInfoM.BlogComments.Comments.Add(tmp);
            }

            return View(detInfoM);
        }
    }
}