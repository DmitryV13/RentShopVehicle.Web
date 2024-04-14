using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.Domain.Entities.User.DB
{
    public class BankInfoDB
    {
        [Key, ForeignKey("User")]
        public int Id { get; set; }
        
        [Required]
        public string ValidDate { get; set; }
        
        [Required]
        public string Number { get; set; }
        
        [Required]
        public string Credentials { get; set; }
        
        [Required]
        public int Number3 { get; set; }
        
        public UserDB User { get; set; }
    }
}
