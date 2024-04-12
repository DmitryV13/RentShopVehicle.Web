using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentShopVehicle.BusinessLogic.Services;

namespace RentShopVehicle.Controllers
{
    public class BaseController : Controller
    {
        private readonly ISession session;

        public BaseController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            session = bl.getSessionS();
        }

        public void UpdateSessionStatus()
        {
            HttpCookie currentCookies = Request.Cookies["RSV-CC"];
            if (currentCookies != null)
            {
                bool responce = session.VerifySession(currentCookies.Value);
                if (responce)
                {
                    System.Web.HttpContext.Current.Session["SessionStatus"] = "valid";
                }
                else
                {
                    System.Web.HttpContext.Current.Session.Clear(); //for server
                    if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("RSV-CC")) // for browser
                    {
                        var cookies = ControllerContext.HttpContext.Request.Cookies["RSV-CC"];
                        if (cookies != null)
                        {
                            cookies.Expires = DateTime.Now.AddDays(-1);
                            ControllerContext.HttpContext.Response.Cookies.Add(cookies);
                        }
                    }
                    System.Web.HttpContext.Current.Session["SessionStatus"] = "invalid";
                }
            }
            else
            {
                System.Web.HttpContext.Current.Session["SessionStatus"] = "invalid";
            }
        }
    }
}