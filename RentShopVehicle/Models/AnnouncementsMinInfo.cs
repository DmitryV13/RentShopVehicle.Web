using RentShopVehicle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentShopVehicle.Domain.Entities.Announcement;

namespace RentShopVehicle.Models
{
    public class AnnouncementsMinInfo
    {
        public List<AnnouncementMinInfoD> Announcements { get; set; }
    }
}