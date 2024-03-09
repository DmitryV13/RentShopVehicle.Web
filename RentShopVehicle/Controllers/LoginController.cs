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
            LoginData lData = new LoginData
            {
                Login = lModel.Login,
                Password = lModel.Password,
                IP = "",
            };

            VerificationResponse vResponse = session.CredentialsVerification(lData);
            if(vResponse != null && vResponse.Exist) {

                //  user exists logic


                // if exists for example we redirect him to "Contacts"
                return RedirectToAction("Contacts", "Home");
            }
                //  user doesn't exist logic


            return RedirectToAction("Login", "Login");
        }
    }
}