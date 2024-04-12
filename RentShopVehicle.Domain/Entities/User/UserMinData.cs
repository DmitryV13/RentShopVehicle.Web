using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.Domain.Entities.User
{
    public class UserMinData
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string LoginIP { get; set; }
        public DateTime LastEntry { get; set; }
    }
}
