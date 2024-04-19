using RentShopVehicle.Domain.Entities.Announcement;
using RentShopVehicle.Domain.Entities.Car.DB;
using RentShopVehicle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentShopVehicle.Models
{
    public class AnnouncementDetInfo
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }

        public string VIN { get; set; }

        public int Mileage { get; set; }

        public Transmission Transmission { get; set; }

        public AnnouncementDB Announcement { get; set; }

        public ICollection<ProductImageDB> Images { get; set; }
    }
}