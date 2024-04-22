using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.Domain.Entities.User
{
    public class LoginHistoryD
    {
        public string LoginIP { get; set; }
        public DateTime LastEntry { get; set; }
    }
}
