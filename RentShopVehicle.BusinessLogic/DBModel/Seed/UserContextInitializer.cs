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
            UserDB admin1 = new UserDB()
            {
                Id = 1,
                Username = "admin",
                Password = HashGenerator.HashGenerate("12345678"),
                UserRole = Role.Admin1,
            };
            var admin1LH = new LoginHistoryDB()
            {
                LastEntry = DateTime.Now,
                LoginIP = HttpContext.Current.Request.UserHostAddress,
            };
            admin1.LoginHistories.Add(admin1LH);
            admin1LH.User = admin1;

            context.Users.Add(admin1);
            context.LoginHistory.Add(admin1LH);

            
            context.SaveChanges();
        }
    }
}
