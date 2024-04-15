using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentShopVehicle.Domain.Entities.Announcement;
using RentShopVehicle.Domain.Entities.Car;

namespace RentShopVehicle.BusinessLogic.Interfaces
{
    public interface IDeals
    {
        ResponceFindCar FindCar(CarD car);
        bool CreateAnnouncement(CreateAnnouncementD announcementD);
    }
}
