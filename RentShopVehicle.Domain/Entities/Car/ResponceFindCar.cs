using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.Domain.Entities.Car
{
    public class ResponceFindCar
    {
        public bool Found { get; set; }
        public CarDB car{ get; set;}
    }
}
