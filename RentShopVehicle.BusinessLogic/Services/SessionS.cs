using RentShopVehicle.BusinessLogic.Core;
using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.Domain.Entities.ServiceE;
using RentShopVehicle.Domain.Entities.User;
using System.Web;

namespace RentShopVehicle.BusinessLogic.Services
{
    public class SessionS : UserAPI, ISession
    {
        public Response CreateUserAccount(RegistrationData rData)
        {
            return CreateUserAccountUserAPI(rData);
        }

        public Response CredentialsVerification(LoginData lData)
        {
            return CredentialsVerificationUserAPI(lData);
        }

        public HttpCookie GenerateCookies(string creds)
        {
            return GenerateCookiesUserAPI(creds);
        }
    }
}
