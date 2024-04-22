using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.Filters.AuthFilters;
using RentShopVehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentShopVehicle.Controllers
{
    public class PrivateAccountController : BaseController
    {
        IUsersManagement umanagement;
        public PrivateAccountController() {
            var bl = new BusinessLogic.BusinessLogic();
            umanagement = bl.GetUsersManagementS();
        }

        public ActionResult Profile()
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [AuthAdmin1]
        [HttpGet]
        public ActionResult AllUsers()
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            UsersInfo usersInfo = new UsersInfo();
            usersInfo.userInfos=umanagement.getAllUsers();

            return View(usersInfo);
        }

        [AuthAdmin1]
        [HttpGet]
        public ActionResult DeleteUser(int Id)
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            var response = umanagement.DeleteUserById(Id);

            return RedirectToAction("AllUsers", "PrivateAccount");
        }

        [AuthAdmin1]
        [HttpGet]
        public ActionResult BlockUser(int Id)
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            var response = umanagement.BlockUserById(Id);

            return RedirectToAction("AllUsers", "PrivateAccount");
        }

        [AuthAdmin1]
        [HttpGet]
        public ActionResult UnblockUser(int Id)
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            var response = umanagement.UnblockUserById(Id);

            return RedirectToAction("AllUsers", "PrivateAccount");
        }
    }
}