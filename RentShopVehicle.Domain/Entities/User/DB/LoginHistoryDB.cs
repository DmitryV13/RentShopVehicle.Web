using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.Domain.Entities.User
{
    public class LoginHistoryDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string LoginIP { get; set; }

        [Required]
        public DateTime LastEntry { get; set; }

        public int UserId { get; set; }

        public UserDB User { get; set; }
    }
}
