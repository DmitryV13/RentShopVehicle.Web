using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentShopVehicle.Models
{
    public class AddPhotosModel
    {
        public int AnnouncementId { get; set; }
        public List<HttpPostedFileBase> Images { get; set; }
    }
}