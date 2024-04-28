using RentShopVehicle.Domain.Entities.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.BusinessLogic.Interfaces
{
    public interface IBlog
    {
        bool AddBlogComment(BlogCommentD blogComment);
        List<BlogCommentD> GetAllBlogComments();
    }
}
