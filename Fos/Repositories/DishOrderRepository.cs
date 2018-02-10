using Fos.Data;
using Fos.Models;
using Fos.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Repositories
{
    public class DishOrderRepository : IDishOrderRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IDishesRepository dishesRepository;

        public DishOrderRepository(ApplicationDbContext dbContext, IDishesRepository dishesRepository)
        {
            this.dbContext = dbContext;
            this.dishesRepository = dishesRepository;
        }

        public bool CreateForOrder(Order order, Dish dish)
        {
            var dishOrder = new DishOrder
            {
                Dish = dish,
                Order = order,
                UpdatedAt = DateTime.Now,
            };
            dbContext.DishOrders.Add(dishOrder);
            return dbContext.SaveChanges() > 0;
        }

        public DishOrder Get(Order order, Dish dish)
        {
            return dbContext.DishOrders.Where(d => d.OrderId == order.Id && d.DishId == dish.Id).FirstOrDefault();
        }

        public bool LinkDishesToOrder(IDictionary<int, int> dishWithAmount, Order order)
        {
            foreach (KeyValuePair<int, int> entry in dishWithAmount)
            {
                if (entry.Value > 0)
                {
                    var dish = dishesRepository.Get(entry.Key);
                    for (var current = 0; current < entry.Value; current++)
                    {
                        CreateForOrder(order, dish);
                    }
                }
            }
            return dbContext.SaveChanges() > 0;
        }

        public bool RemoveAllDishesFromOrder(Order order)
        {
            var allDishOrders = dbContext.DishOrders.Where(d => d.OrderId == order.Id).ToArray();
            foreach(var dishOrder in allDishOrders)
            {
                dbContext.DishOrders.Remove(dishOrder);
            }
            return dbContext.SaveChanges() > 0;
        }

        public bool RemoveFromOrder(Order order, Dish dish)
        {
            var toRemove = dbContext.DishOrders.Where(d => d.OrderId == order.Id && d.DishId == dish.Id).FirstOrDefault();
            if (toRemove == null) return false;
            dbContext.DishOrders.Remove(toRemove);
            return dbContext.SaveChanges() > 0;
        }
    }
}
