using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentShopVehicle.Domain.Entities.Car;

namespace RentShopVehicle.BusinessLogic.Interfaces
{
    public interface ICar
    {
        ResponceFindCar FindCar(CarD car);
    }
}
