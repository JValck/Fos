using Fos.Data;
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
        private readonly IDishesRepository dishesRepository;

        public OrderRepository(ApplicationDbContext dbContext, IStatusRepository statusRepository, IDishesRepository dishesRepository)
        {
            this.dbContext = dbContext;
            this.statusRepository = statusRepository;
            this.dishesRepository = dishesRepository;
        }

        public bool CreateOrder(int[] dishWithAmount, Client client, DinnerTable dinnerTable)
        {
            throw new NotImplementedException();
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

        public bool UpdateOrder(int[] dishWithAmount, Client client, DinnerTable dinnerTable)
        {
            throw new NotImplementedException();
        }
    }
}
