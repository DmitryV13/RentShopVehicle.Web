using RentShopVehicle.Filters.AuthFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentShopVehicle.Controllers
{
    public class PrivateAccountController : BaseController
    {
        // GET: PrivateAccount
        //[AuthAdmin1]
        public ActionResult Profile()
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}