using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fos.Helpers;
using Fos.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Fos.Controllers
{
    public class OrderController : Controller
    {
        private readonly IClientRepository clientRepository;
        private readonly IDishesRepository dishesRepository;
        private readonly IUserHelper userHelper;

        public OrderController(IClientRepository clientRepository, IDishesRepository dishesRepository, IUserHelper userHelper)
        {
            this.clientRepository = clientRepository;
            this.dishesRepository = dishesRepository;
            this.userHelper = userHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int clientId)
        {
            return View();
        }
    }
}