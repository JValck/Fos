using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fos.Models.UserViewModels;
using Microsoft.Extensions.Localization;

namespace Fos.Controllers
{
    [Authorize(Roles = RoleName.Admin + "," + RoleName.Cashier)]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IStringLocalizer<UserController> _localizer;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IStringLocalizer<UserController> localizer)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Manage()
        {
            var model = new ManageViewModel()
            {
                Roles = roleManager.Roles.ToList(),
                Users = userManager.Users.ToList(),
            };            
            return View(model);
        }
        
        public IActionResult AddWaiter()
        {
            ViewData["Title"] = _localizer["Ober toevoegen"];
            return View("AddUser");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWaiter(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(await AddUserAsync(model, RoleName.Waiter))
                {
                    return RedirectToAction(nameof(UserController.Manage), "User");
                }
            }
            return View("AddUser", model);
        }

        private async Task<bool> AddUserAsync(AddUserViewModel model, string role)
        {
            bool succeeded = false;
            var user = new ApplicationUser { UserName = model.UserName };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var roleResult = await userManager.AddToRoleAsync(user, role);
                if (roleResult.Succeeded)
                {
                    succeeded = true;
                }
                AddErrors(roleResult);
            }
            AddErrors(result);
            return succeeded;
        }

        public IActionResult AddCashier()
        {
            ViewData["Title"] = _localizer["Kassier toevoegen"];
            return View("AddUser");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCashier(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await AddUserAsync(model, RoleName.Cashier))
                {
                    return RedirectToAction(nameof(UserController.Manage), "User");
                }
            }
            return View("AddUser", model);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if(!await userManager.IsInRoleAsync(user, RoleName.Admin)){
                await userManager.DeleteAsync(user);
            }
            return RedirectToAction(nameof(UserController.Manage), "User");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }


    }
}