using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fos.Models;

namespace Fos.Helpers
{
    public interface IUserHelper
    {
        ApplicationUser GetUser();
    }
}
