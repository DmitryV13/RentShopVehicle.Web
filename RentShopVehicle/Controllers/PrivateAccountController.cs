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
        public ActionResult Profile()
        {
            return View();
        }
    }
}