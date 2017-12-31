using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fos.Controllers
{
    [Authorize(Roles = (RoleName.Admin))]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}