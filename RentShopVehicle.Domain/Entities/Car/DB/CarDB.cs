using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentShopVehicle.Domain.Entities.Announcement;
using RentShopVehicle.Domain.Enums;

namespace RentShopVehicle.Domain.Entities.Car
{
    public class CarDB
    {
        [Key, ForeignKey("Announcement")]
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }

        public string VIN { get; set; }

        public int Mileage { get; set; }

        public Transmission Transmission { get; set; }

        public AnnouncementDB Announcement { get; set; }
    }
}
