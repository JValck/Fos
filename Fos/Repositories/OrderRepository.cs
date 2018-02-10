﻿using Fos.Data;
using Fos.Models;
using Fos.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IStatusRepository statusRepository;
        private readonly IDishOrderRepository dishOrderRepository;

        public OrderRepository(ApplicationDbContext dbContext, IStatusRepository statusRepository, IDishOrderRepository dishOrderRepository)
        {
            this.dbContext = dbContext;
            this.statusRepository = statusRepository;
            this.dishOrderRepository = dishOrderRepository;
        }

        public bool CreateOrder(IDictionary<int, int> dishWithAmount, Client client, DinnerTable dinnerTable)
        {
            var order = new Order
            {
                Client = client,
                DinnerTable = dinnerTable,
                InsertedAt = DateTime.Now,
                Status = statusRepository.GetIncludedStatus(),
                DishOrders = new List<DishOrder>(),
            };
            dbContext.Orders.Add(order);
            dishOrderRepository.LinkDishesToOrder(dishWithAmount, order);
            return dbContext.SaveChanges() > 0;
        }

        public Order Get(int id)
        {
            return dbContext.Orders.Find(id);
        }

        public bool RemoveOrder(int id)
        {
            var toRemove = dbContext.Orders.Find(id);
            dbContext.Orders.Remove(toRemove);
            return dbContext.SaveChanges() > 0;
        }

        public bool RemoveOrder(Order order)
        {
            return RemoveOrder(order.Id);
        }

        public bool UpdateOrder(Order order, IDictionary<int, int> dishWithAmount, DinnerTable dinnerTable)
        {
            order.DinnerTable = dinnerTable;
            dishOrderRepository.RemoveAllDishesFromOrder(order);
            dishOrderRepository.LinkDishesToOrder(dishWithAmount, order);
            return dbContext.SaveChanges() > 0;
        }
    }
}
