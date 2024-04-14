using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentShopVehicle.Domain.Entities.User;

namespace RentShopVehicle.Domain.Entities.ServiceE
{
    public class Response
    {
        public bool Exist { get; set; }
        public string ErrorMsg { get; set; }
    }
}
