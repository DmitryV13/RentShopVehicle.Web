using System;
using System.Web;
using System.Web.Mvc;
using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.Domain.Entities.User;
using RentShopVehicle.Models;

namespace RentShopVehicle.Controllers
{
    public class LoginController : BaseController
    {

        public LoginController()
        {
            var tmp = new BusinessLogic.BusinessLogic();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public ActionResult NewPassword()
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult ChangePasswordAction(LoginModel lModel)
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            var lData = new LoginData()
            {
                Password = lModel.Password,
            };

            var responce = session.PasswordVerification(lData);
            if (responce)
            {
                return RedirectToAction("NewPassword", "Login");
            }
            else
            {
                return RedirectToAction("ChangePassword", "Login");
            }
        }

        [HttpPost]
        public ActionResult NewPasswordAction(LoginModel lModel)
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            var lData = new LoginData()
            {
                Password = lModel.Password,
            };

            var responce = session.ChangePassword(lData);
            if (responce)
            {
                CloseSession();
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return RedirectToAction("ChangePassword", "Login");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            CloseSession();
            return RedirectToAction("Index", "Home");
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
                    UpdateSessionStatus();
                    return RedirectToAction("Index", "Home");
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