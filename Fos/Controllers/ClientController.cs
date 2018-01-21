using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fos.Helpers;
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
        private readonly IClientRepository clientRepository;
        private readonly IUserHelper userHelper;

        public ClientController(IDinnerTableRepository dinnerTableRepository, IClientRepository clientRepository, IUserHelper userHelper)
        {
            this.dinnerTableRepository = dinnerTableRepository;
            this.clientRepository = clientRepository;
            this.userHelper = userHelper;
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
                var client = clientRepository.Create(model.Name, dinnerTableRepository.Get(model.TableId), userHelper.GetUser());
                return RedirectToAction(nameof(OrderController.Create), "Order", client.Id);
            }
            model.DinnerTables = dinnerTableRepository.GetAll().OrderBy(t => t.TableNumber).ToList();
            return View(model);
        }

        [Authorize(Roles = RoleName.Waiter + "," + RoleName.Cashier)]
        public IActionResult Search()
        {
            return View(clientRepository.GetAll().OrderBy(c => c.Name).ToList());
        }
    }
}