using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.Domain.Entities.User.DB
{
    public class AddressDB
    {
        [Key, ForeignKey("User")]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Country { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Home { get; set; }

        public string Details { get; set; }

        public UserDB User { get; set; }
    }
}
