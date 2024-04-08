using RentShopVehicle.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentShopVehicle.Domain.Entities.Session;

namespace RentShopVehicle.BusinessLogic.DBModel
{
    public class SessionContext : DbContext
    {
        public SessionContext() : base("name=RentShopVehicle") { }

        public virtual DbSet<SessionDB> Sessions { get; set; }
    }
}
