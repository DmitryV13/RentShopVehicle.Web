using RentShopVehicle.Domain.Entities.Car;
using RentShopVehicle.Domain.Entities.ServiceE;
using RentShopVehicle.Domain.Entities.User;
using RentShopVehicle.Domain.Entities.Session;
using RentShopVehicle.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RentShopVehicle.BusinessLogic.DBModel;

namespace RentShopVehicle.BusinessLogic.Core
{
    public class UserAPI
    {
        public VerificationResponse CredentialsVerificationUserAPI(LoginData lData)
        {

            var response = new VerificationResponse();
            if (lData.Password == "password" && lData.Credential == "login")
            {
                response.Exist = true;
                response.user = new UserData
                {
                    Password = "password",
                    Credential = "login",
                };
            }
            else
            {
                response.Exist = false;
            }

            return response;
        }

        public HttpCookie GenerateCookiesUserAPI(string creds)
        {
            var cookies = new HttpCookie("RSV-CC")
            {
                Value = CookieGenerator.Create(creds)
            };

            using (var db = new SessionContext())
            {
                SessionDB current;
                Credential newCreds = new Credential();

                var emailValidation = new EmailAddressAttribute();
                if (emailValidation.IsValid(creds))
                {
                    current = (from el in db.Sessions where el.Cred.Email == creds select el).FirstOrDefault();
                    newCreds.Email = creds;
                    newCreds.Username = null;
                }
                else
                {
                    current = (from el in db.Sessions where el.Cred.Username == creds select el).FirstOrDefault();
                    newCreds.Email = null;
                    newCreds.Username = creds;
                }

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
                        Cred = newCreds,
                        CookieString = cookies.Value,
                        ExpireTime = DateTime.Now.AddHours(2)
                    });
                    db.SaveChanges();
                }
            }

            return cookies;
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
    }
}
