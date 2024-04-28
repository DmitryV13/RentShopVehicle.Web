using RentShopVehicle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentShopVehicle.Models
{
    public class DeliveryM
    {
        public int Id { get; set; }
        public DeliveryType DeliveryType { get; set; }
    }
}