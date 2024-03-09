using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentShopVehicle.BusinessLogic.Core;
using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.Domain.Entities.Car;

namespace RentShopVehicle.BusinessLogic.Services
{
    public class CarS : UserAPI, ICar
    {
        public ResponceFindCar FindCar(CarD car){
            return FindCarUserAPI(car);
        }
    }
}
