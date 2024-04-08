using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentShopVehicle.Domain.Entities.User;

namespace RentShopVehicle.BusinessLogic.DBModel
{
    public class UserContext: DbContext
    {
        public UserContext() : base("name=RentShopVehicle") { }

        public virtual DbSet<UserDB> Users { get; set; }
    }

}
