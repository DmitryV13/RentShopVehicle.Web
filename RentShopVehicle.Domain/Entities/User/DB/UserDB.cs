using RentShopVehicle.Domain.Entities.Announcement;
using RentShopVehicle.Domain.Entities.Feedback;
using RentShopVehicle.Domain.Entities.User.DB;
using RentShopVehicle.Domain.Enums;
using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.Domain.Entities.User
{
    public class UserDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        //[StringLength(50)]
        public string Username { get; set; }

        [Required]
        //[StringLength(100)]
        public string Password { get; set; }

        //[StringLength(100)]
        public string Email { get; set; }

        [Required]
        public ICollection<LoginHistoryDB> LoginHistories { get; set; }

        [Required]
        public ICollection<MessageDB> Messages { get; set; }

        [Required]
        public ICollection<AnnouncementConnectorDB> Connectors { get; set; }

        [Required]
        public Role UserRole { get; set; }

        [Required]
        public bool AccountState { get; set; }

        public AddressDB Address { get; set; }
        public int a { get; set; }

        public BankInfoDB BankInfo { get; set; }

        public UserDB()
        {
            LoginHistories = new List<LoginHistoryDB>();
            Connectors = new List<AnnouncementConnectorDB>();
            Messages= new List<MessageDB>();
        }
    }
}
