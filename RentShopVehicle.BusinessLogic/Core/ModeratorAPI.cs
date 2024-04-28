using RentShopVehicle.BusinessLogic.DBModel;
using RentShopVehicle.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RentShopVehicle.BusinessLogic.Core
{
    public class ModeratorAPI : UserAPI
    {
        public bool DeleteMessageByIdModAPI(int Id)
        {
            using (var db1 = new UserContext())
            {
                var messageDB = db1.Messages.FirstOrDefault(e => e.Id == Id);
                if (messageDB != null)
                {
                    db1.Messages.Remove(messageDB);
                    db1.SaveChanges();
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
