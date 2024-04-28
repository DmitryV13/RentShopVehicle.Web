using RentShopVehicle.Domain.Entities.Feedback;
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
        bool ChangeUsersAccountStatusById(int Id);
        bool ChangeUserRole(UserInfo UserInfo);
        List<BlogCommentD> GetAllMessages();
    }
}
