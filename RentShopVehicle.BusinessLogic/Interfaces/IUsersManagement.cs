using RentShopVehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.BusinessLogic.Interfaces
{
    public interface IUsersManagement
    {
        List<UserInfo> getAllUsers();
        bool DeleteUserById(int Id);
        bool BlockUserById(int Id);
        bool UnblockUserById(int Id);
    }
}
