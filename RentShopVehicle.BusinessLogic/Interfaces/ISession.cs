using System;
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
        VerificationResponse CredentialsVerification(LoginData lData);
    }
}
