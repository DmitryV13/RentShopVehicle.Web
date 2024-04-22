using RentShopVehicle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentShopVehicle.Models
{
    public class CreateAnnouncementM
    {
        public Make Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }

        public string VIN { get; set; }

        public int Mileage { get; set; }

        public int HP { get; set; }

        public Transmission Transmission { get; set; }

        public AnnouncementType Type { get; set; }

        public decimal Price { get; set; }
    }
}