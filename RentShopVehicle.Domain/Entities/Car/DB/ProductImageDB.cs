using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentShopVehicle.Domain.Entities.User;

namespace RentShopVehicle.Domain.Entities.Car.DB
{
    public class ProductImageDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public byte[] FileData { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        public CarDB Car { get; set; }
    }
}
