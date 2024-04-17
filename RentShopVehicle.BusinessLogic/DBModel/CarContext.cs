using RentShopVehicle.Domain.Entities.Announcement;
using RentShopVehicle.Domain.Entities.Car;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace RentShopVehicle.BusinessLogic.DBModel
{
    public class CarContext : DbContext
    {
        public CarContext() : base("name=RentShopVehicle")
        {
            Database.SetInitializer<CarContext>(new DropCreateDatabaseIfModelChanges<CarContext>());
        }// CreateDatabaseIfNotExists

        public virtual DbSet<AnnouncementDB> Announcements { get; set; }
        public virtual DbSet<CarDB> Cars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarDB>()
                .HasOptional(e => e.Announcement)
                .WithRequired(e => e.Car);
        }
    }
}
