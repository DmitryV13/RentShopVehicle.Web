using RentShopVehicle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentShopVehicle.Models
{
    public class FilterDataM
    {
        public string Price {  get; set; } 
        public Make Make { get; set; }
        public string Model { get; set; }
        public Transmission Transmission { get; set; }
    }
}