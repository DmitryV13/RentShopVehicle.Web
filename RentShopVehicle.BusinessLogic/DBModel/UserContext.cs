using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using RentShopVehicle.Domain.Entities.Announcement;
using RentShopVehicle.Domain.Entities.User;
using RentShopVehicle.Domain.Entities.User.DB;

namespace RentShopVehicle.BusinessLogic.DBModel
{
    public class UserContext: DbContext
    {
        public UserContext() : base("name=RentShopVehicle") {
            Database.SetInitializer<UserContext>(new DropCreateDatabaseIfModelChanges<UserContext>());
        }

        public virtual DbSet<UserDB> Users { get; set; }
        public virtual DbSet<LoginHistoryDB> LoginHistory { get; set; }

        public virtual DbSet<AnnouncementIdDB> AnnouncementIds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDB>()
                .HasMany(e => e.LoginHistories)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<UserDB>()
                .HasMany(e => e.AnnouncementsIds)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<UserDB>()
                .HasOptional(e => e.Address)
                .WithRequired(e => e.User);

            modelBuilder.Entity<UserDB>()
                .HasOptional(e => e.BankInfo)
                .WithRequired(e => e.User);
        }
    }

}
