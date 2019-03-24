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
    [Authorize(Roles = RoleName.Waiter + "," + RoleName.Cashier)]
    public class ClientController : Controller
    {
        private readonly IDinnerTableRepository dinnerTableRepository;
        private readonly IClientRepository clientRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IStatusRepository statusRepository;
        private readonly IDishOrderRepository dishOrderRepository;

        public ClientController(IDinnerTableRepository dinnerTableRepository, IClientRepository clientRepository, IOrderRepository orderRepository, IStatusRepository statusRepository, IDishOrderRepository dishOrderRepository)
        {
            this.dinnerTableRepository = dinnerTableRepository;
            this.clientRepository = clientRepository;
            this.orderRepository = orderRepository;
            this.statusRepository = statusRepository;
            this.dishOrderRepository = dishOrderRepository;
        }

        public IActionResult Create()
        {
            var model = new CreateViewModel { DinnerTables = dinnerTableRepository.GetAll().OrderBy(t => t.TableNumber).ToList() };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = clientRepository.Create(model.Name, dinnerTableRepository.Get(model.TableId));
                return RedirectToAction(nameof(OrderController.Create), "Order", new { id = client.Id });
            }
            model.DinnerTables = dinnerTableRepository.GetAll().OrderBy(t => t.TableNumber).ToList();
            return View(model);
        }

        public IActionResult Search()
        {
            return View(clientRepository.GetAllThatRequirePayment().OrderBy(c => c.Name).ToList());
        }

        [Authorize(Roles = RoleName.Cashier)]
        public IActionResult Delete(int id)
        {
            var client = clientRepository.Get(id);
            if (client == null) return NotFound();
            return View(client);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.Cashier)]
        public IActionResult Delete(Client client)
        {
            clientRepository.Delete(client);
            return RedirectToAction(nameof(ClientController.Search), "Client");
        }

        [Authorize(Roles = RoleName.Cashier)]
        public IActionResult Pay(int id)
        {
            var client = clientRepository.Get(id);
            if (client == null) return NotFound();
            var model = new PayViewModel
            {
                Orders = orderRepository.GetOrdersForClient(client).Where(o => o.Status != statusRepository.GetPayedStatus()).ToList(),
                TotalMoneyInCashDesk = orderRepository.GetTotalReceivedMoney(),
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.Cashier)]
        public IActionResult Pay(PayViewModel model, int id)
        {
            var client = clientRepository.Get(id);
            if (client == null) return NotFound();
            var payed = orderRepository.MarkAllOrdersAsPayedForClient(client);
            return Json(payed);
        }

        [HttpPost]
        public IActionResult UpdateName(int clientId, string newClientName)
        {
            var client = clientRepository.Get(clientId);
            if (client == null) return NotFound();
            clientRepository.Rename(clientId, newClientName);
            return RedirectToAction(nameof(ClientController.Search), "Client");
        }

        public IActionResult All()
        {
            return View("Search", clientRepository.GetAll().OrderBy(c => c.Name).ToList());
        }
    }
}