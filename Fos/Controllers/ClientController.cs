using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fos.Models;
using Fos.Models.ClientViewModels;
using Fos.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fos.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly IDinnerTableRepository dinnerTableRepository;

        public ClientController(IDinnerTableRepository dinnerTableRepository)
        {
            this.dinnerTableRepository = dinnerTableRepository;
        }

        [Authorize(Roles = RoleName.Waiter)]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = RoleName.Waiter+","+RoleName.Cashier)]
        public IActionResult Create()
        {
            var model = new CreateViewModel { DinnerTables = dinnerTableRepository.GetAll().OrderBy(t => t.TableNumber).ToList() };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.Waiter + "," + RoleName.Cashier)]
        public IActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO
            }
            model.DinnerTables = dinnerTableRepository.GetAll().OrderBy(t => t.TableNumber).ToList();
            return View(model);
        }
    }
}