﻿using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.BusinessLogic
{
    public class BusinessLogic
    {
        public ISession getSessionS()
        {
            return new SessionS();
        }

        public ICar getCarS()
        {
            return new CarS();
        }
    }
}