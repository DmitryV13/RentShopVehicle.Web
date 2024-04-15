using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentShopVehicle.Filters.AuthFilters
{
    public class AuthAdmin2Attribute : ActionFilterAttribute
    {
        protected readonly ISession session;
        public AuthAdmin2Attribute()
        {
            var bl = new BusinessLogic.BusinessLogic();
            session = bl.getSessionS();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            HttpCookie currentCookies = HttpContext.Current.Request.Cookies["RSV-CC"];
            if (currentCookies != null)
            {
                var currentUser = session.getUserByCookies(currentCookies.Value);
                if (currentUser == null || 
                    currentUser.UserRole != Role.Admin2 || 
                    currentUser.UserRole != Role.Admin1)
                {
                    context.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(
                            new { controller = "Error", action = "E404" }));
                }
            }
        }
    }
}