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
using RentShopVehicle.Domain.Entities.Car.DB;
using System.IO;

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
                AccountState = true,
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
                    el => el.Password == hashedPassword && el.Username == lData.Username && el.AccountState);
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
                HP = announcementD.HP,
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
                Owner=true,
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

        private CarDB GetCarDBById(int Id)
        {
            CarDB carDB = null;
            using (var db = new CarContext())
            {
                carDB = db.Cars.FirstOrDefault(x => x.Id == Id);
            }
            return carDB;
        }

        public List<AnnouncementD> GetUsersAnnouncementsByUserIdUserAPI(int Id)
        {
            List<AnnouncementConnectorDB> annConnList;
            List<AnnouncementD> annListD = new List<AnnouncementD>();

            using (var db1 = new CarContext())
            using (var db = new UserContext())
            {
                annConnList = db.Connectors.Where(e =>
                e.UserId == Id).ToList();
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

        public bool AddPhotosUserAPI(AddPhotosData photosD)
        {
            CarDB carDB = GetCarDBById(photosD.AnnouncementId);
            if(carDB == null)
            {
                return false;
            }
            using(var db = new CarContext())
            {
                for (var i = 0; i<photosD.Images.Count; i++)
                {
                    ProductImageDB tmp = new ProductImageDB()
                    {
                        FileData = photosD.Images[i],
                        Car = carDB,
                    };
                    db.Images.Add(tmp);
                    carDB.Images.Add(tmp);
                }
                db.Entry(carDB).State = EntityState.Modified;
                db.SaveChanges();
            }
            return true;
        }

        public AnnouncementDetInfoD getAnnDetInfoByIdUserAPI(int Id)
        {
            AnnouncementDetInfoD detInfoD = null;
            CarDB carDB = GetCarDBById(Id);
            if (carDB == null)
            {
                return detInfoD;
            }
            detInfoD = new AnnouncementDetInfoD()
            {
                HP = carDB.HP,
                VIN = carDB.VIN,
                Make = carDB.Make,
                Model = carDB.Model,
                Transmission = carDB.Transmission,
                Year = carDB.Year,
                Color = carDB.Color,
                Id = Id,
                Mileage = carDB.Mileage,
                Images = new List<byte[]>(),
            };

            using(var db = new CarContext())
            {
                detInfoD.Price=db.Announcements.FirstOrDefault(e=>e.Id == Id).Price;
                var images = db.Images.Where(e => e.CarId == carDB.Id).ToList();
                for(int i = 0; i< images.Count; i++)
                {
                    detInfoD.Images.Add(images[i].FileData);
                }
            }
            return detInfoD;
        }

        public bool DeleteAnnouncementByIdUserAPI(int Id)
        {
            AnnouncementDB annDB;
            CarDB carDB;

            using (var db1  = new UserContext())
            using(var db2 = new CarContext())
            {
                annDB = db2.Announcements.FirstOrDefault(x => x.Id == Id);
                carDB = db2.Cars.FirstOrDefault(x => x.Id == Id);

                if (annDB == null)
                    return false;

                var connectors = db1.Connectors.Where(e => e.AnnouncementId == annDB.Id).ToList();
                for (int i = 0; i < connectors.Count; i++)
                {
                    db1.Connectors.Remove(connectors[i]);
                }

                var messages = db1.Messages.Where(e => e.AnnouncementId == annDB.Id).ToList();
                for (int i = 0; i < messages.Count; i++)
                {
                    db1.Messages.Remove(messages[i]);
                }
                db2.Announcements.Remove(annDB);

                var images = db2.Images.Where(e => e.CarId == carDB.Id).ToList();
                for (int i = 0;i< images.Count;i++)
                {
                    db2.Images.Remove(images[i]);
                }
                db2.Cars.Remove(carDB);

                db1.SaveChanges();
                db2.SaveChanges();
            }


            return true;
        }

        public List<AnnouncementMinInfoD> getAnnouncementByFilterUserAPI(FilterData filter)
        {
            List<AnnouncementMinInfoD> infoDs = new List<AnnouncementMinInfoD>();
            if(filter == null) { 
                filter= new FilterData();
            }

            using(var db = new UserContext())
            using(var db1 =new CarContext())
            {
                var consDB = db.Connectors.Where(e=> 
                    e.Owner == true &&
                    e.Status == AnnouncementStatus.Undone).ToList();
                for(int i = 0; i< consDB.Count; i++)
                {
                    int announcementId = consDB[i].AnnouncementId;
                    var annDB = db1.Announcements.FirstOrDefault(e => 
                    e.Id == announcementId &&
                    ((filter.min == 0) ? true : e.Price >= filter.min) &&
                    ((filter.max == 0) ? true : e.Price <= filter.max)
                    );
                    if (annDB != null)
                    {
                        var carDB = db1.Cars.FirstOrDefault(e =>
                        e.Id == annDB.Id &&
                        ((filter.Make == Make.None) ? true : e.Make == filter.Make) &&
                        ((filter.Model == null) ? true : e.Model == filter.Model) &&
                        ((filter.Transmission == Transmission.None) ? true : e.Transmission == filter.Transmission)
                        );

                        if (carDB != null)
                        {
                            var images = db1.Images.Where(e => e.CarId == carDB.Id).ToList();

                            AnnouncementMinInfoD tmp = new AnnouncementMinInfoD()
                            {
                                Id = annDB.Id,
                                Make = carDB.Make,
                                Model = carDB.Model,
                                Transmission = carDB.Transmission,
                                Price = annDB.Price,
                                Year = carDB.Year,
                                Mileage = carDB.Mileage,
                                HP = carDB.HP,
                                Type = consDB[i].Type,
                                ImageUrls = new List<string>(),
                            };
                            for (int j = 0; j < images.Count; j++)
                            {
                                tmp.ImageUrls.Add($"data:image;base64,{Convert.ToBase64String(images[j].FileData)}");
                            }
                            infoDs.Add(tmp);
                        }
                    }
                }
            }

            return infoDs;
        }

        public AnnouncementDetInfoD getCarDetailByIdUserAPI(int Id)
        {
            AnnouncementDetInfoD infoD = null;
            using (var db1 = new UserContext())
            using (var db = new CarContext())
            {
                var annDB = db.Announcements.FirstOrDefault(e => e.Id == Id);
                var carDB = db.Cars.FirstOrDefault(e => e.Id == Id);

                infoD = new AnnouncementDetInfoD()
                {
                    Id = Id,
                    HP = carDB.HP,
                    VIN = carDB.VIN,
                    Make = carDB.Make,
                    Model = carDB.Model,
                    Transmission = carDB.Transmission,
                    Year = carDB.Year,
                    Color = carDB.Color,
                    Mileage = carDB.Mileage,
                    Images = new List<byte[]>(),
                    Price = annDB.Price,
                };
                var images = db.Images.Where(e => e.CarId == carDB.Id).ToList();
                for (int i = 0; i < images.Count; i++)
                {
                    infoD.Images.Add(images[i].FileData);
                }
            }
            return infoD;
        }

        public bool MakePurchaseUserAPI(int Id)
        {
            using (var db1 = new UserContext())
            using (var db = new CarContext())
            {
                var connDB = db1.Connectors.FirstOrDefault(e => e.AnnouncementId == Id);
                connDB.Status = AnnouncementStatus.Done;
                var user = (HttpContext.Current.Session["SessionUser"] as UserMinData);
                var userDB = db1.Users.FirstOrDefault(e=>e.Id == user.Id);
                AnnouncementConnectorDB tmp = new AnnouncementConnectorDB()
                {
                    Type = AnnouncementType.Purchase,
                    Status = AnnouncementStatus.Done,
                    AnnouncementId = Id,
                    Owner = false,
                    User = userDB,
                };

                db1.Entry(connDB).State = EntityState.Modified;
                db1.Connectors.Add(tmp);
                db1.SaveChanges();
            }

            return true;
        }
    }
}
