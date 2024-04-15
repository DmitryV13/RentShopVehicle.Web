using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentShopVehicle.BusinessLogic.Core;
using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.Domain.Entities.Announcement;
using RentShopVehicle.Domain.Entities.Car;
using RentShopVehicle.Domain.Enums;

namespace RentShopVehicle.BusinessLogic.Services
{
    public class DealsS : UserAPI, IDeals
    {
        public ResponceFindCar FindCar(CarD car){
            return FindCarUserAPI(car);
        }
        public bool CreateAnnouncement(CreateAnnouncementD announcementD)
        {
            return CreateAnnouncementUserAPI(announcementD);
        }
    }
}
