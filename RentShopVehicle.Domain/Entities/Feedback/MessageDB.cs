using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentShopVehicle.Domain.Enums;
using RentShopVehicle.Domain.Entities.User;
using RentShopVehicle.Domain.Entities.Announcement;

namespace RentShopVehicle.Domain.Entities.Feedback
{
    public class MessageDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public MessageType MessageType { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public int AnnouncementId { get; set; }
    }
}
