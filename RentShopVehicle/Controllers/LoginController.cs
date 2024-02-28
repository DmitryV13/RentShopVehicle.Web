using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentShopVehicle.BusinessLogic;
using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.Models;

namespace RentShopVehicle.Controllers
{
    public class LoginController : Controller
    {
        internal ISession session;

        public LoginController()
        {
            var tmp = new BusinessLogic.BusinessLogic();
            session = tmp.getSessionS();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAction(LoginModel model)
        {
            string h = model.Password;
            return View();
        }
    }
}