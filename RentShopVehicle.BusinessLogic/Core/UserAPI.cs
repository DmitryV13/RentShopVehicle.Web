using RentShopVehicle.Domain.Entities.Car;
using RentShopVehicle.Domain.Entities.ServiceE;
using RentShopVehicle.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
