﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentShopVehicle.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult E404()
        {
            return View();
        }

        public ActionResult E500()
        {
            return View();
        }
    }
}