using RentShopVehicle.Domain.Entities.Announcement;
using RentShopVehicle.Domain.Entities.User.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentShopVehicle.Models
{
    public class AllAnnouncements
    {
        public List<AnnouncementConnectorDB> AnnouncementConnectors { get; set; }
    }
}