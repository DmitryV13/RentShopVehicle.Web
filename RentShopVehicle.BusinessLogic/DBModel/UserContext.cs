using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using RentShopVehicle.BusinessLogic.DBModel.Seed;
using RentShopVehicle.Domain.Entities.Announcement;
using RentShopVehicle.Domain.Entities.Feedback;
using RentShopVehicle.Domain.Entities.User;
using RentShopVehicle.Domain.Entities.User.DB;
using RentShopVehicle.Domain.Enums;
using RentShopVehicle.Helpers;

namespace RentShopVehicle.BusinessLogic.DBModel
{
    public class UserContext: DbContext
    {
        public UserContext() : base("name=RentShopVehicle") {
            Database.SetInitializer<UserContext>(new UserContextInitializer());
        }

        public virtual DbSet<UserDB> Users { get; set; }
        public virtual DbSet<LoginHistoryDB> LoginHistory { get; set; }
        public virtual DbSet<MessageDB> Messages { get; set; }
        public virtual DbSet<AnnouncementConnectorDB> Connectors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDB>()
                .HasMany(e => e.LoginHistories)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<UserDB>()
                .HasMany(e => e.Connectors)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<UserDB>()
                .HasOptional(e => e.Address)
                .WithRequired(e => e.User);

            modelBuilder.Entity<UserDB>()
                .HasOptional(e => e.BankInfo)
                .WithRequired(e => e.User);
        }
    }

}
