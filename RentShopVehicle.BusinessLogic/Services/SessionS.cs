﻿using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.Domain.Entities.ServiceE;
using RentShopVehicle.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.BusinessLogic.Services
{
    public class SessionS : ISession
    {
        public VerificationResponse CredentialsVerification(LoginData lData)
        {
            return new VerificationResponse { };
        }
    }
}
