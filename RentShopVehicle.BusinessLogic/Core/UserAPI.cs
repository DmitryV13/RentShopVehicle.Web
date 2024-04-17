using RentShopVehicle.Domain.Entities.Car;
using RentShopVehicle.Domain.Entities.ServiceE;
using RentShopVehicle.Domain.Entities.User;
using RentShopVehicle.Domain.Entities.Session;
using RentShopVehicle.Helpers;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RentShopVehicle.BusinessLogic.DBModel;
using RentShopVehicle.Domain.Enums;
using RentShopVehicle.Domain.Entities.Announcement;
using RentShopVehicle.Domain.Entities.User.DB;
using System.Collections.Generic;
using System.Net;
using RentShopVehicle.BusinessLogic.DBModel;

namespace RentShopVehicle.BusinessLogic.Core
{
    public class UserAPI
    {
        public Response CreateUserAccountUserAPI(RegistrationData rData)
        {
            var response = new Response();
            response.Exist = true;

            UserDB newUser = getUserByUsername(rData.Username);
            LoginHistoryDB newLHistory;

            if (newUser != null)
            {
                response.Exist = false;
                response.ErrorMsg = "Try another username, this is already occupied!";
                return response;
            }

            newUser = new UserDB()
            {
                Username = rData.Username,
                Password = HashGenerator.HashGenerate(rData.Password),
                Email = rData.Email,
                UserRole=Role.User,
            };
            newLHistory = new LoginHistoryDB()
            {
                LastEntry = DateTime.Now,
                LoginIP = HttpContext.Current.Request.UserHostAddress,
            };
            newUser.LoginHistories.Add(newLHistory);
            newLHistory.User=newUser;

            using(var db = new UserContext())
            {
                db.Users.Add(newUser);
                db.LoginHistory.Add(newLHistory);
                db.SaveChanges();
            }
            return response;
        }

        public Response CredentialsVerificationUserAPI(LoginData lData)
        {
            var response = new Response();
            response.Exist = true;

            UserDB userDB;
            var hashedPassword = HashGenerator.HashGenerate(lData.Password);

            using(var db = new UserContext())
            {
                userDB=db.Users.FirstOrDefault(
                    el => el.Password == hashedPassword && el.Username == lData.Username);
            }
            if(userDB == null)
            {
                response.Exist = false;
                response.ErrorMsg = "There is no such user, check credentials, please!";
                return response;
            }

            LoginHistoryDB newLHistory = new LoginHistoryDB()
            {
                LastEntry = DateTime.Now,
                LoginIP = HttpContext.Current.Request.UserHostAddress,
                User=userDB,
            };
            using (var db = new UserContext())
            {
                db.LoginHistory.Add(newLHistory);
                userDB.LoginHistories.Add(newLHistory);
                db.Entry(userDB).State = EntityState.Modified;
                db.SaveChanges();
            }
            return response;
        }

        public HttpCookie GenerateCookiesUserAPI(string transmittedUsername)
        {
            var cookies = new HttpCookie("RSV-CC")
            {
                Value = CookieGenerator.Create(transmittedUsername)
            };

            using (var db = new SessionContext())
            {
                SessionDB current;

                current = (
                    from el in db.Sessions 
                    where el.Username == transmittedUsername 
                    select el
                    ).FirstOrDefault();

                if (current != null)
                {
                    current.CookieString = cookies.Value;
                    current.ExpireTime = DateTime.Now.AddHours(2);
                    using (var db_context = new SessionContext())
                    {
                        db_context.Entry(current).State = EntityState.Modified;
                        db_context.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new SessionDB
                    {
                        Username = transmittedUsername,
                        CookieString = cookies.Value,
                        ExpireTime = DateTime.Now.AddHours(2)
                    });
                    db.SaveChanges();
                }
            }
            return cookies;
        }

        public bool VerifySessionUserAPI(string cookies)
        {
            SessionDB currentSession;
            using (var db = new SessionContext())
            {
                currentSession = db.Sessions.FirstOrDefault(el => el.CookieString == cookies);

                if (currentSession != null)
                {
                    UserDB sessionOwner = getUserByUsername(currentSession.Username);
                    if (currentSession.ExpireTime < DateTime.Now || sessionOwner == null)
                    {
                        db.Sessions.Remove(currentSession);
                        db.SaveChanges();
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        private UserDB getUserByUsername(string username)
        {
            UserDB userDB;
            using (var db = new UserContext())
            {
                userDB = db.Users.FirstOrDefault(el => el.Username == username);
            }
            return userDB;
        }

        public ResponceFindCar FindCarUserAPI(CarD car)
        {
            var responce = new ResponceFindCar()
            {
                Found = false,
            };
            if (car.Price == "$800 - $3200.100")
            {
                responce.Found = true;
            }
            return responce;
        }

        public UserMinData getUserByCookiesUserAPI(string cookies)
        {
            UserMinData userMinData = null;
            UserDB sessionOwner = getUserDBByCookiesUser(cookies);

            if(sessionOwner != null)
            {
                userMinData = new UserMinData()
                {
                    Username = sessionOwner.Username,
                    Email = sessionOwner.Email,
                    UserRole = sessionOwner.UserRole,
                    Id = sessionOwner.Id,
                };
            }
            return userMinData;
        }

        private UserDB getUserDBByCookiesUser(string cookies)
        {
            SessionDB currentSession;
            using (var db = new SessionContext())
            {
                currentSession = db.Sessions.FirstOrDefault(el => el.CookieString == cookies);
            }
            UserDB sessionOwner = null;
            if (currentSession != null)
            {
                sessionOwner = getUserByUsername(currentSession.Username);
            }
            return sessionOwner;
        }

        public void CloseCurrentSessionUserAPI(string cookies)
        {
            UserMinData userMinData = null;
            SessionDB currentSession;
            UserDB sessionOwner = null;
            using (var db = new SessionContext())
            {
                currentSession = db.Sessions.FirstOrDefault(el => el.CookieString == cookies);
                if (currentSession != null)
                {
                    currentSession.ExpireTime = DateTime.Now.AddDays(-1);
                }
                db.Entry(currentSession).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public bool CreateAnnouncementUserAPI(CreateAnnouncementD announcementD)
        {
            if(announcementD.UserCookies == null) {
                return false;
            }
            UserDB userDB = getUserDBByCookiesUser(announcementD.UserCookies);
            CarDB carDB = new CarDB()
            {
                Make = announcementD.Make,
                Model = announcementD.Model,
                Year = announcementD.Year,
                Color = announcementD.Color,
                VIN = announcementD.VIN,
                Mileage = announcementD.Mileage,
                Transmission = announcementD.Transmission,
            };
            AnnouncementDB announcementDB = new AnnouncementDB()
            {
                Price = announcementD.Price,
                Car = carDB,
            };
            carDB.Announcement=announcementDB;

            AnnouncementConnectorDB announcementConnectorDB = new AnnouncementConnectorDB()
            {
                Type = announcementD.Type,
                Status = AnnouncementStatus.Undone,
                User = userDB,
            };
            userDB.Connectors.Add(announcementConnectorDB);

            using(var db = new UserContext())
            using(var db1 = new CarContext())
            {
                db1.Cars.Add(carDB);
                db1.Announcements.Add(announcementDB);

                db1.SaveChanges();

                announcementConnectorDB.AnnouncementId = announcementDB.Id;
                db.Connectors.Add(announcementConnectorDB);
                db.Entry(userDB).State = EntityState.Modified;

                db.SaveChanges();
            }

            return true;
        }

        private UserDB GetUserDBById(int Id)
        {
            UserDB userDB = null;
            using (var db = new UserContext())
            {
                userDB = db.Users.FirstOrDefault(x => x.Id == Id);
            }
            return userDB;
        }


        public List<AnnouncementD> GetAnnouncementConnectorsByUserIdUserAPI(int Id)
        {
            List<AnnouncementConnectorDB> annConnList;
            List<AnnouncementD> annListD = new List<AnnouncementD>();

            using (var db1 = new CarContext())
            using (var db = new UserContext())
            {
                annConnList = db.Connectors.Where(e =>
                e.UserId == Id &&
                e.Type != AnnouncementType.Purchase &&
                e.Status == AnnouncementStatus.Undone).ToList();
                foreach (var conn in annConnList)
                {
                    var a = db1.Announcements.FirstOrDefault(e => e.Id == conn.AnnouncementId);
                    var tmp = new AnnouncementD()
                    {
                        ConnectorId = conn.Id,
                        AnnouncementId = conn.AnnouncementId,
                        Type = conn.Type,
                        Status = conn.Status,
                        Price = db1.Announcements.FirstOrDefault(e => e.Id == conn.AnnouncementId).Price,
                    };
                    annListD.Add(tmp);
                }
            }
            return annListD;
        }
    }
}
