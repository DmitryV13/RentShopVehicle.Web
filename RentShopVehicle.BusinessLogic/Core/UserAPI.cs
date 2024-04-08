using RentShopVehicle.Domain.Entities.Car;
using RentShopVehicle.Domain.Entities.ServiceE;
using RentShopVehicle.Domain.Entities.User;
using RentShopVehicle.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RentShopVehicle.BusinessLogic.Core
{
    public class UserAPI
    {
        public VerificationResponse CredentialsVerificationUserAPI(LoginData lData)
        {

            var response = new VerificationResponse();
            if (lData.Password == "password" && lData.Login == "login")
            {
                response.Exist = true;
                response.user = new UserData
                {
                    Password = "password",
                    Login = "login",
                };
            }
            else
            {
                response.Exist = false;
            }

            return response;
        }

        public HttpCookie GenerateCookiesForCS(string creds)
        {
            var cookies = new HttpCookie("RSV-CC")
            {
                Value = CookieGenerator.Create(creds)
            };

            using (var db = new SessionContext())
            {
                Session curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredential))
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }
                else
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new SessionContext())
                    {
                        todo.Entry(curent).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
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
