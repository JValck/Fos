using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Fos.Models.UserViewModels
{
    public class ManageViewModel
    {
        public List<IdentityRole> Roles { get; internal set; }
        public List<ApplicationUser> Users { get; internal set; }
    }
}
