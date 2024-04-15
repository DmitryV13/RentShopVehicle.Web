using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentShopVehicle.Domain.Enums;
using RentShopVehicle.Domain.Entities.Announcement;

namespace RentShopVehicle.Domain.Entities.User.DB
{
    public class AnnouncementConnectorDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public AnnouncementType Type { get; set; }

        [Required]
        public AnnouncementStatus Status { get; set; }

        public int UserId { get; set; }

        public UserDB User { get; set; }

        public AnnouncementDB Announcement { get; set; }

        public int AnnouncementId { get; set; }
    }
}
