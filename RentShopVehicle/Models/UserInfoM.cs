using RentShopVehicle.Domain.Entities.User;
using RentShopVehicle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentShopVehicle.Models
{
    public class UserInfoM
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public List<LoginHistoryD> LoginHistories { get; set; }

        public Role UserRole { get; set; }

        public bool AccountState { get; set; }
    }
}