using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentShopVehicle.Filters.AuthFilters
{
    public class AuthAdmin1Attribute : ActionFilterAttribute
    {
        protected readonly ISession session;
        public AuthAdmin1Attribute()
        {
            var bl = new BusinessLogic.BusinessLogic();
            session = bl.getSessionS();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            HttpCookie currentCookies = HttpContext.Current.Request.Cookies["RSV-CC"];
            if (currentCookies != null)
            {
                var currentUser = session.GetUserByCookies(currentCookies.Value);
                bool validRole = currentUser.UserRole == Role.Admin1;
                if (currentUser == null || !validRole)
                {
                    context.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(
                            new { controller = "Error", action = "E404" }));
                }
            }
        }
    }
}