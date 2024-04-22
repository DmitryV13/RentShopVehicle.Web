using RentShopVehicle.Domain.Entities.User;
using RentShopVehicle.Domain.Enums;
using RentShopVehicle.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RentShopVehicle.BusinessLogic.DBModel.Seed
{
    public class UserContextInitializer : DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            //ADMIN1
            UserDB admin1 = new UserDB()
            {
                Id = 1,
                Username = "admin1",
                Email= "1admin123@gmail.com",
                Password = HashGenerator.HashGenerate("12345678"),
                UserRole = Role.Admin1,
                AccountState = true,
            };
            var admin1LH = new LoginHistoryDB()
            {
                LastEntry = DateTime.Now,
                LoginIP = HttpContext.Current.Request.UserHostAddress,
            };
            admin1.LoginHistories.Add(admin1LH);
            admin1LH.User = admin1;
            //ADMIN1

            //ADMIN2
            UserDB admin2 = new UserDB()
            {
                Id = 1,
                Username = "admin2",
                Email = "2admin123@gmail.com",
                Password = HashGenerator.HashGenerate("12345678"),
                UserRole = Role.Admin2,
                AccountState = true,
            };
            var admin2LH = new LoginHistoryDB()
            {
                LastEntry = DateTime.Now,
                LoginIP = HttpContext.Current.Request.UserHostAddress,
            };
            admin2.LoginHistories.Add(admin2LH);
            admin2LH.User = admin2;
            //ADMIN2

            //MODERATOR
            UserDB moderator = new UserDB()
            {
                Id = 1,
                Username = "mod",
                Email = "mod123@gmail.com",
                Password = HashGenerator.HashGenerate("12345678"),
                UserRole = Role.Moderator,
                AccountState = true,
            };
            var moderatorLH = new LoginHistoryDB()
            {
                LastEntry = DateTime.Now,
                LoginIP = HttpContext.Current.Request.UserHostAddress,
            };
            moderator.LoginHistories.Add(moderatorLH);
            moderatorLH.User = moderator;
            //MODERATOR

            //USER1
            UserDB user1 = new UserDB()
            {
                Id = 1,
                Username = "user1",
                Email = "user123@gmail.com",
                Password = HashGenerator.HashGenerate("12345678"),
                UserRole = Role.User,
                AccountState = true,
            };
            var user1LH = new LoginHistoryDB()
            {
                LastEntry = DateTime.Now,
                LoginIP = HttpContext.Current.Request.UserHostAddress,
            };
            user1.LoginHistories.Add(user1LH);
            user1LH.User = user1;
            //USER1

            context.Users.Add(admin1);
            context.Users.Add(admin2);
            context.Users.Add(moderator);
            context.Users.Add(user1);
            context.LoginHistory.Add(admin1LH);
            context.LoginHistory.Add(admin2LH);
            context.LoginHistory.Add(moderatorLH);
            context.LoginHistory.Add(user1LH);


            
            context.SaveChanges();

        }
    }
}
