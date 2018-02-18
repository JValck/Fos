using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fos.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fos.Controllers
{
    public class RedirectController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RedirectController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (await _userManager.IsInRoleAsync(user, RoleName.Admin))
                {
                    return RedirectToAction(nameof(AdminController.Index), "Admin");
                }
                else if (await _userManager.IsInRoleAsync(user, RoleName.Waiter))
                {
                    return RedirectToAction(nameof(ClientController.Index), "Client");
                }else if(await _userManager.IsInRoleAsync(user, RoleName.Cashier))
                {
                    return RedirectToAction(nameof(CashierController.Index), "Cashier");
                }
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }        
    }
}