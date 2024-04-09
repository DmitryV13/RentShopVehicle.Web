using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentShopVehicle.BusinessLogic;
using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.Domain.Entities.User;
using RentShopVehicle.Models;
using RentShopVehicle.Domain.Entities.ServiceE;
using RentShopVehicle.BusinessLogic.DBModel;
using RentShopVehicle.BusinessLogic.Services;
using System.Web.UI.WebControls;

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
        public ActionResult LoginAction(LoginModel lModel)
        {
            if (ModelState.IsValid)
            {
                var lData = new LoginData()
                {
                    Login = lModel.Login,
                    Password = lModel.Password,
                    Entry = DateTime.Now,
                    LoginIP = Request.UserHostAddress,
                };

                var authResp = session.CredentialsVerification(lData);
                if (authResp.Exist)
                {
                    HttpCookie cookie = session.GenerateCookies(lModel.Login);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    return RedirectToAction("Contacts", "Home");
                }
                else
                {
                    ModelState.AddModelError("", authResp.ErrorMsg);
                    return RedirectToAction("Login", "Login");
                }
            }
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult RegistrationAction(RegistrationModel lModel)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Login", "Login");
            }
            return RedirectToAction("Registration", "Login");
        }
    }
}