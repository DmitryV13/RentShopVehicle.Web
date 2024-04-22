using RentShopVehicle.Domain.Entities.Car;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentShopVehicle.Domain.Entities.Announcement
{
    public class AnnouncementDB
    {
        [Key, ForeignKey("Car")]
        public int Id { get; set; }

        [Required]
        public CarDB Car { get; set; }

        [Required]
        public decimal Price { get; set; }

        public AnnouncementDB()
        {
        }
    }
}
