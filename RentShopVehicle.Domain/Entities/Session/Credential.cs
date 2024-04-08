using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.Domain.Entities.Session
{
    public class Credential
    {
        [StringLength(30)]
        public string Username { get; set; }

        [StringLength(30)]
        public string Email { get; set; }
    }
}
