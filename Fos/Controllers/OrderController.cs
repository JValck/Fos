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
        private readonly IOrderRepository orderRepository;
        private readonly IDishOrderRepository dishOrderRepository;

        public OrderController(IClientRepository clientRepository, IDishesRepository dishesRepository, IDinnerTableRepository dinnerTableRepository, IUserHelper userHelper, IOrderRepository orderRepository, IDishOrderRepository dishOrderRepository)
        {
            this.clientRepository = clientRepository;
            this.dishesRepository = dishesRepository;
            this.dinnerTableRepository = dinnerTableRepository;
            this.userHelper = userHelper;
            this.orderRepository = orderRepository;
            this.dishOrderRepository = dishOrderRepository;
        }

        [Route("[controller]/[action]/{clientId}")]
        public IActionResult Create(int clientId)
        {
            if (!clientRepository.Exists(clientId)) return NotFound();
            var model = new FormViewModel
            {
                ClientId = clientId,
            };
            FillViewModelLists(ref model, clientId, Guid.Empty);
            return View(model);
        }

        [HttpPost]
        [Route("[controller]/[action]/{clientId}")]
        public IActionResult Create(int clientId, FormViewModel model)
        {
            Dictionary<string, string> data = Request.Form.ToDictionary(d => d.Key, d => d.Value.ToString());
            model.ClientId = Convert.ToInt32(data["ClientId"]);
            if (!ModelState.IsValid)
            {
                ReloadViewData(ref model, ref data, Guid.Empty);
                return View(model);
            }
            var saved = orderRepository.CreateOrder(ExtractDishesWithAmountFromSubmittedData(data), clientRepository.Get(model.ClientId), dinnerTableRepository.Get(model.TableId), userHelper.GetUser());
            return (saved) ? Saved():NotSaved();
        }

        private void ReloadViewData(ref FormViewModel model, ref Dictionary<string, string> data, Guid tableId)
        {
            FillViewModelLists(ref model, model.ClientId, tableId);
            MergeDishOrders(ref model, ref data);
        }

        private void MergeDishOrders(ref FormViewModel model, ref Dictionary<string, string> data)
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

        /// <summary>
        /// Sets the lists on the viewmodel
        /// </summary>
        /// <param name="model"></param>
        /// <param name="clientId"></param>
        /// <param name="tableId">Where the order should be delivered. Guid.Empty if the default should be used</param>
        private void FillViewModelLists(ref FormViewModel model, int clientId, Guid tableId)
        {
            model.KitchenDishes = dishesRepository.GetAllAvailableGroupedByKitchen();
            model.Tables = dinnerTableRepository.GetAll();
            model.TableId = (tableId == Guid.Empty) ? clientRepository.Get(clientId).DinnerTableClients.Select(dt => dt.DinnerTable.Id).Last() : tableId;
            model.DishOrders = dishesRepository.GetAll().ToDictionary(d => d.Id, d => 0);
        }

        private IActionResult Saved()
        {
            return View("Saved");
        }

        private IActionResult NotSaved()
        {
            return View("NotSaved");
        }

        [Route("[controller]/[action]/{clientId}")]
        public IActionResult AllFor(int clientId)
        {
            var client = clientRepository.Get(clientId);
            if (client == null) return NotFound();
            ViewData["ClientId"] = client.Id;
            return View(orderRepository.GetOrdersForClient(client));
        }

        public IActionResult Detail(int id)
        {
            var order = orderRepository.Get(id);
            if (order == null) return NotFound();
            return View(order);
        }

        public IActionResult Edit(int id)
        {
            var order = orderRepository.Get(id);
            if (order == null) return NotFound();
            FormViewModel viewModel = new UpdateViewModel();
            viewModel.ClientId = order.ClientId;
            var mapped = dishOrderRepository.MapDishAndAmountFor(order).ToDictionary(m => m.Key.ToString(), m => m.Value.ToString());
            ReloadViewData(ref viewModel, ref mapped, order.DinnerTableId);            
            return View("Create", viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, FormViewModel viewModel)
        {
            var order = orderRepository.Get(id);
            if (order == null) return NotFound();
            viewModel.ClientId = order.ClientId;
            Dictionary<string, string> data = Request.Form.ToDictionary(d => d.Key, d => d.Value.ToString());
            if (!ModelState.IsValid)
            {
                ReloadViewData(ref viewModel, ref data, viewModel.TableId);
                return View("Create", viewModel);
            }
            var table = dinnerTableRepository.Get(viewModel.TableId);
            var saved = orderRepository.UpdateOrder(order, ExtractDishesWithAmountFromSubmittedData(data), table, userHelper.GetUser());
            return (saved) ? Saved() : NotSaved();
        }

        private IDictionary<int,int> ExtractDishesWithAmountFromSubmittedData(IDictionary<string, string> data)
        {
            int parsed = 0;
            return data.Where(d => int.TryParse(d.Key, out parsed)).ToDictionary(d => parsed, d => int.Parse(d.Value));
        }
        
    }
}