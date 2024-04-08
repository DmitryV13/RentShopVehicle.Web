using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.Domain.Entities.User
{
    public class UserData
    {
        public int Id { get; set; }
        public string Name { get; set; }     
        public string Credential { get; set; }
        public string Password { get; set; }
    }
}
