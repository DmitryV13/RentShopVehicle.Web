using RentShopVehicle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.Domain.Entities.Announcement
{
    public class AnnouncementD
    {
        public int ConnectorId { get; set; }
        public int AnnouncementId { get; set; }
        public AnnouncementType Type { get; set; }
        public AnnouncementStatus Status { get; set; }
        public decimal Price { get; set; }
    }
}
