﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentShopVehicle.Domain.Entities.Announcement;
using RentShopVehicle.Domain.Enums;
using RentShopVehicle.Domain.Entities.User.DB;
using RentShopVehicle.Domain.Entities.Car.DB;

namespace RentShopVehicle.Domain.Entities.Car
{
    public class CarDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Make Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string VIN { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public int HP { get; set; }

        [Required]
        public Transmission Transmission { get; set; }

        public AnnouncementDB Announcement { get; set; }

        public ICollection<ProductImageDB> Images { get; set; }

        public CarDB()
        {
            Images = new List<ProductImageDB>();
        }
    }
}
