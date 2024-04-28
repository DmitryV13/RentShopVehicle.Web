using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentShopVehicle.Domain.Entities.ServiceE;
using RentShopVehicle.Domain.Entities.User;

namespace RentShopVehicle.BusinessLogic.Interfaces
{
    public interface ISession
    {
        Response CreateUserAccount(RegistrationData rData);
        Response CredentialsVerification(LoginData lData);
        HttpCookie GenerateCookies(string creds);
        bool VerifySession(string cookies);
        UserMinData getUserByCookies(string cookies);
        void CloseCurrentSession(string cookies);
        bool PasswordVerification(LoginData lData);
        bool ChangePassword(LoginData lData);
    }
}
