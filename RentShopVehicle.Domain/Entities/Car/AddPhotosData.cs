using System.Collections.Generic;

namespace RentShopVehicle.Domain.Entities.Car
{
    public class AddPhotosData
    {
        public int AnnouncementId { get; set; }
        public List<byte[]> Images { get; set; }
    }
}
