using System.Data.Entity;
using RentShopVehicle.Domain.Entities.Session;

namespace RentShopVehicle.BusinessLogic.DBModel
{
    public class SessionContext : DbContext
    {
        public SessionContext() : base("name=RentShopVehicle") {
            Database.SetInitializer<SessionContext>(new DropCreateDatabaseIfModelChanges<SessionContext>());
        }

        public virtual DbSet<SessionDB> Sessions { get; set; }
    }
}
