using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.BusinessLogic
{
    public class BusinessLogic
    {
        public ISession getSessionS()
        {
            return new SessionS();
        }

        public IDeals getDealsS()
        {
            return new DealsS();
        }

        public IUsersManagement GetUsersManagementS()
        {
            return new UsersManagementS();
        }

        public IMsgsManagement GetMsgsManagementS()
        {
            return new MsgsManagementS();
        }

        public IBlog GetBlogS()
        {
            return new BlogS();
        }
    }
}
