using RentShopVehicle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.Domain.Entities.Announcement
{
    public class AnnouncementMinInfoD
    {
        public int Id { get; set; }

        public Make Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int Mileage { get; set; }

        public int HP { get; set; }

        public decimal Price { get; set; }

        public Transmission Transmission { get; set; }

        public AnnouncementType Type { get; set; }

        public List<string> ImageUrls { get; set; }
    }
}
