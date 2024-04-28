using RentShopVehicle.BusinessLogic.Core;
using RentShopVehicle.BusinessLogic.Interfaces;
using RentShopVehicle.Domain.Entities.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.BusinessLogic.Services
{
    public class BlogS: UserAPI, IBlog
    {
        public bool AddBlogComment(BlogCommentD blogComment)
        {
            return AddBlogCommentUserAPI(blogComment);
        }

        public List<BlogCommentD> GetAllBlogComments()
        {
            return GetAllBlogCommentsUserAPI();
        }
    }
}
