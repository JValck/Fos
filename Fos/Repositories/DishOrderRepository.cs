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

        public DishOrderRepository(ApplicationDbContext dbContext, IStatusRepository statusRepository)
        {
            this.dbContext = dbContext;
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

        public bool RemoveFromOrder(Order order, Dish dish)
        {
            var toRemove = dbContext.DishOrders.Where(d => d.OrderId == order.Id && d.DishId == dish.Id).FirstOrDefault();
            if (toRemove == null) return false;
            dbContext.DishOrders.Remove(toRemove);
            return dbContext.SaveChanges() > 0;
        }
    }
}
