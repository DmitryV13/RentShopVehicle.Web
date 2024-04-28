using RentShopVehicle.Domain.Entities.Feedback;
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

        public AnnouncementType Type { get; set; }

        public AnnouncementStatus Status { get; set; }

        public Make Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }

        public string VIN { get; set; }

        public int Mileage { get; set; }

        public int HP { get; set; }

        public decimal Price { get; set; }

        public Transmission Transmission { get; set; }

        public int RentTimeInDays { get; set; }

        public List<string> ImageUrls { get; set; }

        public string UserCookies { get; set; }

        public List<BlogCommentD> BlogComments { get; set; }
    }
}
