using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.BusinessLogic.Services;
using RentShopVehicle.Domain.Enums;
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
        IUsersManagement u_management;
        IMsgsManagement m_management;
        public PrivateAccountController() {
            var bl = new BusinessLogic.BusinessLogic();
            u_management = bl.GetUsersManagementS();
            m_management = bl.GetMsgsManagementS();
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
            usersInfo.userInfos=u_management.getAllUsers();

            return View(usersInfo);
        }

        [AuthModerator]
        [HttpGet]
        public ActionResult AllMessages()
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            BlogComments blogComments = new BlogComments()
            {
                Comments = new List<BlogComment>(),
            };
            var commentsD = u_management.GetAllMessages();
            for (var i = 0; i < commentsD.Count; i++)
            {
                var tmp = new BlogComment()
                {
                    Id = commentsD[i].Id,
                    UserId = commentsD[i].UserId,
                    Created = commentsD[i].Created,
                    AnnouncementId = commentsD[i].AnnouncementId,
                    MessageType = commentsD[i].MessageType,
                    Comment = commentsD[i].Comment,
                    UserName = commentsD[i].UserName,
                };
                blogComments.Comments.Add(tmp);
            }
            return View(blogComments);
        }

        [AuthModerator]
        [HttpGet]
        public ActionResult DeleteMessage(int Id)
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            var response = m_management.DeleteMessageById(Id);

            return RedirectToAction("AllMessages", "PrivateAccount");
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

            var response = u_management.DeleteUserById(Id);

            return RedirectToAction("AllUsers", "PrivateAccount");
        }

        [AuthAdmin1]
        [HttpGet]
        public ActionResult ChangeUsersAccountStatus(int Id)
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            var response = u_management.ChangeUsersAccountStatusById(Id);

            return RedirectToAction("AllUsers", "PrivateAccount");
        }

        [AuthAdmin1]
        [HttpPost]
        public ActionResult ChangeUserRole(UserInfoM userInfoM)
        {
            UpdateSessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["SessionStatus"] != "valid")
            {
                return RedirectToAction("Index", "Home");
            }

            UserInfo userInfoD = new UserInfo()
            {
                Id = userInfoM.Id,
                UserRole = userInfoM.UserRole,
            };

            var response = u_management.ChangeUserRole(userInfoD);

            return RedirectToAction("AllUsers", "PrivateAccount");
        }
    }
}