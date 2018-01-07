using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fos.Models;
using Fos.Models.KitchenViewModels;
using Fos.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fos.Controllers
{
    [Authorize]
    public class KitchenController : Controller
    {
        private readonly IKitchenRepository kitchenRepository;

        public KitchenController(IKitchenRepository kitchenRepository)
        {
            this.kitchenRepository = kitchenRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = RoleName.Admin)]
        public IActionResult Manage()
        {
            var model = new ManageViewModel()
            {
                Kitchens = kitchenRepository.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.Admin)]
        public IActionResult Create(ManageViewModel model)
        {
            if (ModelState.IsValid)
            {
                kitchenRepository.Add(new Kitchen
                {
                    Name = model.Name
                });
                return RedirectToAction(nameof(KitchenController.Manage), "Kitchen");
            }
            model.Kitchens = kitchenRepository.GetAll();
            return View("Manage", model);
        }

        [Authorize(Roles = RoleName.Admin)]
        public IActionResult Delete(int id)
        {
            kitchenRepository.Delete(id);
            return RedirectToAction(nameof(KitchenController.Manage), "Kitchen");
        }

        [Authorize(Roles = RoleName.Admin)]
        public IActionResult Update(int id)
        {
            var kitchen = kitchenRepository.Get(id);
            if (kitchen == null) return NotFound();
            var model = new UpdateViewModel
            {
                Name = kitchen.Name
            };
            return View(model);
        }

        [Authorize(Roles = RoleName.Admin)]
        [HttpPost]
        public IActionResult Update(int id, UpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                kitchenRepository.UpdateKitchenName(id, model.Name);
                return RedirectToAction(nameof(KitchenController.Manage), "Kitchen");
            }
            return View(model);
        }
    }
}