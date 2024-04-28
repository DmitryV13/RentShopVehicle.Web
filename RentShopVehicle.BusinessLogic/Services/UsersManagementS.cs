using RentShopVehicle.BusinessLogic.Core;
using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.Domain.Entities.Feedback;
using RentShopVehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.BusinessLogic.Services
{
    public class UsersManagementS :Admin1API, IUsersManagement
    {
        public List<UserInfo> getAllUsers()
        {
            return getAllUsersAdmin1API();
        }

        public bool DeleteUserById(int Id)
        {
            return DeleteUserByIdAdmin1API(Id);
        }

        public bool ChangeUsersAccountStatusById(int Id)
        {
            return ChangeUsersAccountStatusByIdAdmin1API(Id);
        }

        public bool ChangeUserRole(UserInfo UserInfo)
        {
            return ChangeUserRoleAdminAPI(UserInfo);
        }

        public List<BlogCommentD> GetAllMessages()
        {
            return GetAllBlogCommentsAdminAPI();
        }

    }
}
