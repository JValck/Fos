using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fos.Helpers;
using Fos.Models;
using Fos.Models.OrderViewModels;
using Fos.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fos.Controllers
{
    [Authorize]
    [Authorize(Roles = RoleName.Cashier + ", " + RoleName.Waiter)]
    public class OrderController : Controller
    {
        private readonly IClientRepository clientRepository;
        private readonly IDishesRepository dishesRepository;
        private readonly IDinnerTableRepository dinnerTableRepository;
        private readonly IUserHelper userHelper;

        public OrderController(IClientRepository clientRepository, IDishesRepository dishesRepository, IDinnerTableRepository dinnerTableRepository, IUserHelper userHelper)
        {
            this.clientRepository = clientRepository;
            this.dishesRepository = dishesRepository;
            this.dinnerTableRepository = dinnerTableRepository;
            this.userHelper = userHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("[controller]/[action]/{clientId}")]
        public IActionResult Create(int clientId)
        {
            if (!clientRepository.Exists(clientId)) return NotFound();
            var x = dishesRepository.GetAll().ToDictionary(d => d.Id, d => d.Price);
            var model = new CreateViewModel
            {
                ClientId = clientId,
            };
            FillViewModelLists(ref model, clientId);
            return View(model);
        }

        [HttpPost]
        [Route("[controller]/[action]/{clientId}")]
        public IActionResult Create(int clientId, CreateViewModel model)
        {
            Dictionary<string, string> data = Request.Form.ToDictionary(d => d.Key, d => d.Value.ToString());
            model.ClientId = Convert.ToInt32(data["ClientId"]);
            if (!ModelState.IsValid)
            {
                FillViewModelLists(ref model, clientId);                
                MergeDishOrders(ref model, ref data);
                return View(model);
            }
            return RedirectToAction(nameof(OrderController.Index), "Order");
        }

        private void MergeDishOrders(ref CreateViewModel model, ref Dictionary<string, string> data)
        {
            int dishId;
            foreach(var item in data)
            {
                if(int.TryParse(item.Key, out dishId))
                {
                    model.DishOrders[dishId] = int.Parse(item.Value);
                }
            }
        }

        private void FillViewModelLists(ref CreateViewModel model, int clientId)
        {
            model.KitchenDishes = dishesRepository.GetAllGroupedByKitchen();
            model.Tables = dinnerTableRepository.GetAll();
            model.TableId = clientRepository.Get(clientId).DinnerTableClients.Select(dt => dt.DinnerTable.Id).Last();
            model.DishOrders = dishesRepository.GetAll().ToDictionary(d => d.Id, d => 0);
        }

        public IActionResult Saved()
        {
            return View();
        }
    }
}