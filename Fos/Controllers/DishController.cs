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
using Microsoft.AspNetCore.Http;
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
                string imagePath = await SaveImage(viewModel.Image);
                dishesRepository.Add(new Dish
                {
                    Description = viewModel.Description,
                    Price = Convert.ToDouble(viewModel.Price),
                    ImageUrl = imagePath,
                    KitchenId = viewModel.KitchenId
                });
                return RedirectToAction(nameof(DishController.Manage), "Dish");
            }
            viewModel.Dishes = dishesRepository.GetAll();
            viewModel.Kitchens = kitchenRepository.GetAll();
            return View("Manage", viewModel);
        }

        private async Task<string> SaveImage(IFormFile Image, string imagePath = null)
        {
            if (Image != null)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                var extension = Path.GetExtension(Image.FileName).ToLower();
                if (allowedExtensions.Contains(extension))
                {
                    var fileName = Guid.NewGuid().ToString() + extension;
                    imagePath = Path.Combine(storageOptions.Value.ImageUploadPath, fileName);
                    var fullPath = Path.Combine(_hostingEnvironment.WebRootPath, imagePath);
                    await storage.SaveAsync(Image, fullPath);

                }
                else
                {
                    ModelState.AddModelError("Image", _localizer["Ongeldig bestandstype"]);
                }
            }
            return imagePath;
        }

        [Authorize(Roles = RoleName.Admin)]
        public IActionResult Delete(int id)
        {
            DeleteImage(id);
            dishesRepository.Delete(id);
            return RedirectToAction(nameof(DishController.Manage), "Dish");
        }

        private void DeleteImage(int id)
        {
            var dish = dishesRepository.Get(id);
            if (dish != null && dish.ImageUrl != null)
            {
                storage.Delete(Path.Combine(_hostingEnvironment.WebRootPath, dish.ImageUrl));
            }
        }

        [Authorize(Roles = RoleName.Admin)]
        public IActionResult Update(int id)
        {
            var dish = dishesRepository.Get(id);
            if (dish == null) return NotFound();
            var model = new UpdateViewModel
            {
                Description = dish.Description,
                ImageUrl = dish.ImageUrl,
                KitchenId = dish.KitchenId,
                Price = dish.Price,
                Kitchens = kitchenRepository.GetAll(),
            };
            return View(model);
        }

        [Authorize(Roles = RoleName.Admin)]
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateViewModel model)
        {
            var dish = dishesRepository.Get(id);
            if (ModelState.IsValid && dish != null)
            {
                DeleteImage(id);
                string imagePath = await SaveImage(model.Image);
                dishesRepository.Update(id, model.Description, Convert.ToDouble(model.Price), model.KitchenId, imagePath);
                return RedirectToAction(nameof(DishController.Manage), "Dish");
            }
            model.Kitchens = kitchenRepository.GetAll();
            return View(model);
        }

        /// <summary>
        /// Method used by the cashier to see stats of the sold dishes
        /// Allows a dish to be exhausted
        /// </summary>
        /// <returns>ActionResult</returns>
        [Authorize(Roles = RoleName.Admin+","+RoleName.Cashier)]
        public IActionResult Active()
        {
            var data = dishesRepository.GetAllGroupedByKitchenWithDishOrders();
            return View();
        }
    }
}