using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentShopVehicle.BusinessLogic.Core;
using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.Domain.Entities.Announcement;
using RentShopVehicle.Domain.Entities.Car;
using RentShopVehicle.Domain.Entities.User.DB;
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

        public bool AddPhotos(AddPhotosData photosD)
        {
            return AddPhotosUserAPI(photosD);
        }

        public List<AnnouncementD> GetAnnouncementConnectorsByUserId(int Id)
        {
            return GetUsersAnnouncementsByUserIdUserAPI(Id);
        }

        public AnnouncementDetInfoD getAnnouncementDetInfoById(int Id)
        {
            return getAnnDetInfoByIdUserAPI(Id);
        }

        public bool DeleteAnnouncementById(int Id)
        {
            return DeleteAnnouncementByIdUserAPI(Id);
        }

        public List<AnnouncementMinInfoD> getAnnouncementByFilter(FilterData filter)
        {
            return getAnnouncementByFilterUserAPI(filter);
        }

        public AnnouncementDetInfoD getCarDetailById(int Id)
        {
            return getCarDetailByIdUserAPI(Id);
        }

        public bool MakePurchase(int Id)
        {
            return MakePurchaseUserAPI(Id);
        }
    }
}
