using RentShopVehicle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentShopVehicle.Models
{
    public class BlogComment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public MessageType MessageType { get; set; }
        public DateTime Created { get; set; }
        public int AnnouncementId { get; set; }
    }
}