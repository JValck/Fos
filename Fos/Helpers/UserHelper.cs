using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fos.Data;
using Fos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Fos.Helpers
{
    public class UserHelper:IUserHelper
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserHelper(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.httpContextAccessor = httpContextAccessor;
        }

        public ApplicationUser GetUser()
        {
            return dbContext.Users.Where(user => user.UserName == httpContextAccessor.HttpContext.User.Identity.Name).First();
        }
    }
}
