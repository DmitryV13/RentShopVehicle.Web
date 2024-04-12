using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentShopVehicle.Models
{
    public class RegistrationModel
    {
        public string Username { get; set; }

        public string Password1 { get; set; }

        public string Password2 { get; set; }

        public string Email { get; set; }
    }
}