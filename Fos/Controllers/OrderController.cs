using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fos.Helpers;
using Fos.Models.OrderViewModels;
using Fos.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Fos.Controllers
{
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
                KitchenDishes = dishesRepository.GetAllGroupedByKitchen(),
                Tables = dinnerTableRepository.GetAll(),
                TableId = clientRepository.Get(clientId).DinnerTableClients.Select(dt => dt.DinnerTable.Id).Last(),
                DishOrders = dishesRepository.GetAll().ToDictionary(d => d.Id, d => 0),
            };
            return View(model);
        }
    }
}