﻿using RentShopVehicle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.Domain.Entities.Feedback
{
    public class BlogCommentD
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
