using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fos.Models;
using Fos.Models.TableViewModels;
using Fos.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fos.Controllers
{
    [Authorize]
    public class TableController : Controller
    {
        private readonly IDinnerTableRepository dinnerTableRepository;

        public TableController(IDinnerTableRepository dinnerTableRepository)
        {
            this.dinnerTableRepository = dinnerTableRepository;
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
                Tables = dinnerTableRepository.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.Admin)]
        public IActionResult Create(ManageViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            model.Tables = dinnerTableRepository.GetAll();
            return View("Manage", model);
        }

    }
}