using RentShopVehicle.BusinessLogic.Core;
using RentShopVehicle.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.BusinessLogic.Services
{
    public class MsgsManagementS: ModeratorAPI, IMsgsManagement
    {
        public bool DeleteMessageById(int Id)
        {
            return DeleteMessageByIdModAPI(Id);
        }
    }
}
