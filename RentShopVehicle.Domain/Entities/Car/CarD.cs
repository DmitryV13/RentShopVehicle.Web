using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.Domain.Entities.Car
{
    public class CarD
    {
        public string Year { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Mileage { get; set; }
        public int HP { get; set; }
        public string Price { get; set; }
    }
}
