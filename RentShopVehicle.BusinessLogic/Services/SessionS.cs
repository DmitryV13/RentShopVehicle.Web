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

        public bool VerifySession(string cookies)
        {
            return VerifySessionUserAPI(cookies);
        }

        public UserMinData GetUserByCookies(string cookies)
        {
            return getUserByCookiesUserAPI(cookies);
        }
        public UserMinData GetUserById(int Id)
        {
            return getUserByIdUserAPI(Id);
        }

        public void CloseCurrentSession(string cookies)
        {
            CloseCurrentSessionUserAPI(cookies);
        }

        public bool PasswordVerification(LoginData lData)
        {
            return PasswordVerificationUserAPI(lData);
        }

        public bool ChangePassword(LoginData lData)
        {
            return ChangePasswordUserAPI(lData);
        }
    }
}
