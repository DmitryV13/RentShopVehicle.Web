using RentShopVehicle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.Domain.Entities.Car
{
    public class FilterData
    {
        public int min = 0;
        public int max = 0;
        public Make Make { get; set; }
        public string Model { get; set; }
        public Transmission Transmission { get; set; }
    }
}
