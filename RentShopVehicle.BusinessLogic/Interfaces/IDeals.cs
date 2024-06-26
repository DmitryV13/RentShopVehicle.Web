﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentShopVehicle.Domain.Entities.Announcement;
using RentShopVehicle.Domain.Entities.Car;
using RentShopVehicle.Domain.Entities.User.DB;

namespace RentShopVehicle.BusinessLogic.Interfaces
{
    public interface IDeals
    {
        ResponceFindCar FindCar(CarD car);
        bool CreateAnnouncement(AnnouncementDetInfoD announcementD);
        bool AddPhotos(AddPhotosData photosD);
        List<AnnouncementD> GetAnnouncementConnectorsByUserId(int Id);
        AnnouncementDetInfoD getAnnouncementDetInfoById(int Id);
        bool DeleteAnnouncementById(int Id);
        List<AnnouncementDetInfoD> getAnnouncementByFilter(FilterData filter);
        AnnouncementDetInfoD getCarDetailById(int Id);
        bool MakePurchase(int Id);
    }
}
