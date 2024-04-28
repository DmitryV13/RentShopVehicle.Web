using RentShopVehicle.BusinessLogic.DBModel;
using RentShopVehicle.Domain.Entities.Feedback;
using RentShopVehicle.Domain.Entities.User;
using RentShopVehicle.Domain.Enums;
using RentShopVehicle.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
            var user = (HttpContext.Current.Session["SessionUser"] as UserMinData);
            if (user.Id == Id)
                return false;
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

        public bool ChangeUsersAccountStatusByIdAdmin1API(int Id)
        {
            var user = (HttpContext.Current.Session["SessionUser"] as UserMinData);
            if (user.Id == Id)
                return false;
            using (var db1 = new UserContext())
            {
                var userDB = db1.Users.FirstOrDefault(e => e.Id == Id);
                if (userDB.AccountState)
                {
                    userDB.AccountState = false;
                }
                else
                {
                    userDB.AccountState = true;
                }
                db1.Entry(userDB).State = EntityState.Modified;
                db1.SaveChanges();
            }

            return true;
        }

        public bool ChangeUserRoleAdminAPI(UserInfo userInfo)
        {
            var user = (HttpContext.Current.Session["SessionUser"] as UserMinData);
            if (user.Id == userInfo.Id)
                return false;
            using (var db1 = new UserContext())
            {
                var userDB = db1.Users.FirstOrDefault(e => e.Id == userInfo.Id);
                userDB.UserRole=userInfo.UserRole;
                db1.Entry(userDB).State = EntityState.Modified;
                db1.SaveChanges();
            }

            return true;
        }

        public List<BlogCommentD> GetAllBlogCommentsAdminAPI()
        {
            List<BlogCommentD> blogComments = new List<BlogCommentD>();
            using (var db1 = new UserContext())
            {
                var commentsDB = db1.Messages.ToList();
                foreach (var comment in commentsDB)
                {
                    var userDB = db1.Users.FirstOrDefault(e => e.Id == comment.UserId);
                    var commentD = new BlogCommentD()
                    {
                        Id= comment.Id,
                        Comment = comment.Message,
                        UserName = userDB == null ? "Unknown" : userDB.Username,
                        MessageType = comment.MessageType,
                        UserId = comment.UserId,
                        Created = comment.Created,
                        AnnouncementId = comment.AnnouncementId,
                    };
                    blogComments.Add(commentD);
                }
            }
            return blogComments;
        }
    }
}
