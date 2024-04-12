using System;
using System.Web;
using System.Web.Mvc;
using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.Domain.Entities.User;
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
        public ActionResult LoginAction(LoginModel lModel)
        {
            if (ModelState.IsValid)
            {
                var lData = new LoginData()
                {
                    Username = lModel.Username,
                    Password = lModel.Password,
                    Entry = DateTime.Now,
                    LoginIP = Request.UserHostAddress,
                };

                var authResp = session.CredentialsVerification(lData);
                if (authResp.Exist)
                {
                    HttpCookie cookie = session.GenerateCookies(lModel.Username);
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
        public ActionResult RegistrationAction(RegistrationModel rModel)
        {
            if (ModelState.IsValid)
            {
                if (rModel.Password1 != rModel.Password2)
                {
                    ModelState.AddModelError("", "Password was not typed correct the second time!");
                    return RedirectToAction("Registration", "Login");
                }

                var rData = new RegistrationData()
                {
                    Email = rModel.Email,
                    Password = rModel.Password1,
                    Username = rModel.Username,
                    LoginIP = Request.UserHostAddress,
                    LastEntry = DateTime.Now,
                };

                var resp=session.CreateUserAccount(rData);
                if(!resp.Exist)
                {
                    ModelState.AddModelError("", resp.ErrorMsg);
                    return RedirectToAction("Registration", "Login");
                }

                return RedirectToAction("Login", "Login");
            }
            return RedirectToAction("Registration", "Login");
        }
    }
}