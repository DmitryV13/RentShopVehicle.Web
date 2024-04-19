using RentShopVehicle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.Domain.Entities.Announcement
{
    public class AnnouncementDetInfoD
    {
        public int Id { get; set; }

        public Make Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }

        public string VIN { get; set; }

        public int Mileage { get; set; }

        public decimal Price { get; set; }

        public Transmission Transmission { get; set; }

        public List<byte[]> Images { get; set; }
    }
}
