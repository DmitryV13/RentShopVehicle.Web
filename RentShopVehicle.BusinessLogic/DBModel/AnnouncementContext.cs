using RentShopVehicle.Domain.Entities.Announcement;
using RentShopVehicle.Domain.Entities.Feedback;
using RentShopVehicle.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.BusinessLogic.DBModel
{
    public class AnnouncementContext :DbContext
    {
        public AnnouncementContext() : base("name=RentShopVehicle")
        {
            Database.SetInitializer<AnnouncementContext>(new DropCreateDatabaseIfModelChanges<AnnouncementContext>());
        }

        public virtual DbSet<AnnouncementDB> Announcements { get; set; }
        public virtual DbSet<MessageDB> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnnouncementDB>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Announcement)
                .HasForeignKey(e => e.AnnouncementId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<AnnouncementDB>()
                .HasOptional(e => e.Car)
                .WithRequired(e => e.Announcement);
        }
    }
}
