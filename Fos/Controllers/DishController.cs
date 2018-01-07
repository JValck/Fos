using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Fos.Models;
using Fos.Models.DishViewModels;
using Fos.Options;
using Fos.Repositories.Contracts;
using Fos.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace Fos.Controllers
{
    [Authorize]
    public class DishController : Controller
    {
        private readonly IDishesRepository dishesRepository;
        private readonly IKitchenRepository kitchenRepository;
        private readonly IStorage storage;
        private IOptions<Options.Storage> storageOptions;
        private IHostingEnvironment _hostingEnvironment;
        private readonly IStringLocalizer<DishController> _localizer;

        public DishController(IDishesRepository dishesRepository, IKitchenRepository kitchenRepository, IStorage storage, IOptions<Options.Storage> storageOptions, IHostingEnvironment hostingEnvironment, IStringLocalizer<DishController> localizer)
        {
            this.dishesRepository = dishesRepository;
            this.kitchenRepository = kitchenRepository;
            this.storage = storage;
            this.storageOptions = storageOptions;
            _hostingEnvironment = hostingEnvironment;
            _localizer = localizer;
        }

        [Authorize(Roles = RoleName.Admin)]
        public IActionResult Manage()
        {
            var model = new ManageViewModel()
            {
                Dishes = dishesRepository.GetAll(),
                Kitchens = kitchenRepository.GetAll()
            };
            return View(model);
        }

        [Authorize(Roles = RoleName.Admin)]
        [HttpPost]
        public async Task<IActionResult> Create(ManageViewModel viewModel)
        {            
            if (ModelState.IsValid)
            {
                string imagePath = null;
                if(viewModel.Image != null)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                    var extension = Path.GetExtension(viewModel.Image.FileName).ToLower();
                    if (allowedExtensions.Contains(extension))
                    {
                        var fileName = Guid.NewGuid().ToString() + extension;
                        imagePath = Path.Combine(storageOptions.Value.ImageUploadPath, fileName);
                        var fullPath = Path.Combine(_hostingEnvironment.WebRootPath, imagePath);
                        await storage.SaveAsync(viewModel.Image, fullPath);

                        dishesRepository.Add(new Dish
                        {
                            Description = viewModel.Description,
                            Price = viewModel.Price,
                            ImageUrl = imagePath,
                            KitchenId = viewModel.KitchenId
                        });
                        return RedirectToAction(nameof(DishController.Manage), "Dish");
                    }
                    else
                    {
                        ModelState.AddModelError("Image", _localizer["Ongeldig bestandstype"]);
                    }
                }
            }
            viewModel.Dishes = dishesRepository.GetAll();
            viewModel.Kitchens = kitchenRepository.GetAll();
            return View("Manage", viewModel);
        }

        [Authorize(Roles = RoleName.Admin)]
        public IActionResult Delete(int id)
        {
            //TODO: delete image
            dishesRepository.Delete(id);
            return RedirectToAction(nameof(DishController.Manage), "Dish");
        }
    }
}