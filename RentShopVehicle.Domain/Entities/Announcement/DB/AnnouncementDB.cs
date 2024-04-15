using RentShopVehicle.Domain.Entities.Car;
using RentShopVehicle.Domain.Entities.Feedback;
using RentShopVehicle.Domain.Entities.User;
using RentShopVehicle.Domain.Entities.User.DB;
using RentShopVehicle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.Domain.Entities.Announcement
{
    public class AnnouncementDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public CarDB Car { get; set; }

        [Required]
        public ICollection<MessageDB> Messages { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public ICollection<AnnouncementConnectorDB> Connectors { get; set; }

        public AnnouncementDB()
        {
            Messages = new List<MessageDB>();
            Connectors = new List<AnnouncementConnectorDB>();
        }
    }
}
