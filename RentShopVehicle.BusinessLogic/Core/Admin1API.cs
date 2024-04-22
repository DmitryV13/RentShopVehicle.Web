using RentShopVehicle.BusinessLogic.DBModel;
using RentShopVehicle.Domain.Entities.User;
using RentShopVehicle.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.BusinessLogic.Core
{
    public class Admin1API : Admin2API
    {
        public List<UserInfo> getAllUsersAdmin1API()
        {
            List<UserInfo> users = new List<UserInfo>();
            using(var db = new UserContext())
            {
                var usersDB = db.Users.ToList();
                for(int i = 0; i < usersDB.Count; i++)
                {
                    UserInfo tmp = new UserInfo()
                    {
                        Id = usersDB[i].Id,
                        Username = usersDB[i].Username,
                        Email = usersDB[i].Email,
                        UserRole = usersDB[i].UserRole,
                        AccountState = usersDB[i].AccountState,
                        LoginHistories = new List<Domain.Entities.User.LoginHistoryD>(),
                    };
                    var historiesDB=db.LoginHistory.Where(e=>e.UserId==tmp.Id).ToList();
                    for(int j = 0; j < historiesDB.Count; j++)
                    {
                        LoginHistoryD tmp1 = new LoginHistoryD()
                        {
                            LoginIP = historiesDB[j].LoginIP,
                            LastEntry = historiesDB[j].LastEntry,
                        };
                        tmp.LoginHistories.Add(tmp1);
                    }
                    users.Add(tmp);
                }
            }
            return users;
        }

        public bool DeleteUserByIdAdmin1API(int Id)
        {
            using (var db1 = new UserContext())
            {
                var userDB = db1.Users.FirstOrDefault(e => e.Id == Id);
                var connsDB = db1.Connectors.Where(e=>e.UserId == Id).ToList();
                for (int j = 0;j < connsDB.Count; j++)
                {
                    if (connsDB[j].Owner)
                    {
                        DeleteAnnouncementByIdUserAPI(connsDB[j].AnnouncementId);
                    }
                    db1.Connectors.Remove(connsDB[j]);
                }
                db1.Users.Remove(userDB);
                db1.SaveChanges();
            }


            return true;
        }

        public bool BlockUserByIdAdmin1API(int Id)
        {
            using (var db1 = new UserContext())
            {
                var userDB = db1.Users.FirstOrDefault(e => e.Id == Id);
                userDB.AccountState = false;
                db1.Entry(userDB).State = EntityState.Modified;
                db1.SaveChanges();
            }

            return true;
        }

        public bool UnblockUserByIdAdmin1API(int Id)
        {
            using (var db1 = new UserContext())
            {
                var userDB = db1.Users.FirstOrDefault(e => e.Id == Id);
                userDB.AccountState = true;
                db1.Entry(userDB).State = EntityState.Modified;
                db1.SaveChanges();
            }

            return true;
        }
    }
}
