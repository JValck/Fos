using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fos.Models;
using Fos.Models.SetupViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fos.Controllers
{
    public class SetupController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public SetupController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            Task.Run(CreateRolesIfNotExistAsync).GetAwaiter().GetResult();
            if (Task.Run(() => userManager.FindByNameAsync("Admin")).Result == null)
            {
                return View(new SetupViewModel());
            }
            return View("AlreadyConfigured");
        }

        private async Task CreateRolesIfNotExistAsync()
        {
            if (!await roleManager.RoleExistsAsync(RoleName.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole()
                {
                    Name = RoleName.Admin,
                });
            }
            if (!await roleManager.RoleExistsAsync(RoleName.Cashier))
            {
                await roleManager.CreateAsync(new IdentityRole()
                {
                    Name = RoleName.Cashier,
                });
            }
            if (!await roleManager.RoleExistsAsync(RoleName.Waiter))
            {
                await roleManager.CreateAsync(new IdentityRole()
                {
                    Name = RoleName.Waiter,
                });
            }
        }

        [HttpPost]
        public IActionResult Index(SetupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Task.Run(() => CreateAdminAsync(model)).GetAwaiter().GetResult();

            return RedirectToAction(nameof(AdminController.Index), "Admin");
        }

        private async Task CreateAdminAsync(SetupViewModel model)
        {
            var user = new ApplicationUser()
            {
                UserName = model.UserName,
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(await userManager.FindByNameAsync(model.UserName), RoleName.Admin);
                await signInManager.SignInAsync(user, false);//login
            }            
        }
    }
}