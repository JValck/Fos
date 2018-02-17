using Fos.Data;
using Fos.Models;
using Fos.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
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

        public bool CreateOrder(IDictionary<int, int> dishWithAmount, Client client, DinnerTable dinnerTable, ApplicationUser user)
        {
            var saved = false;
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var order = new Order
                    {
                        Client = client,
                        DinnerTable = dinnerTable,
                        InsertedAt = DateTime.Now,
                        Status = statusRepository.GetIncludedStatus(),
                        DishOrders = new List<DishOrder>(),
                        ApplicationUser = user,
                    };
                    dbContext.Orders.Add(order);
                    dbContext.SaveChanges();
                    saved = dishOrderRepository.LinkDishesToOrder(dishWithAmount, order);                    
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
            return saved;
        }

        public Order Get(int id)
        {            
            return dbContext.Orders
                .Where(o => o.Id == id)
                .Include(o => o.Client)
                .Include(o => o.DinnerTable)
                .Include(o => o.DishOrders).ThenInclude(dishOrder => dishOrder.Dish)
                .FirstOrDefault();
        }

        public Order Get(Client client)
        {
            return Get(client.Id);
        }

        public IList<Order> GetOrdersForClient(Client client)
        {
            return dbContext.Orders.Where(o => o.ClientId == client.Id)
                    .Include(o => o.Status)
                    .Include(o => o.ApplicationUser)
                    .Include(o => o.DinnerTable)
                    .ToList();
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

        public bool UpdateOrder(Order order, IDictionary<int, int> dishWithAmount, DinnerTable dinnerTable, ApplicationUser user)
        {
            var saved = false;
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.Entry(order).State = EntityState.Modified;
                    order.DinnerTable = dinnerTable;
                    order.ApplicationUser = user;
                    order.Status = statusRepository.GetUpdatedStatus();
                    saved = dishOrderRepository.RemoveAllDishesFromOrder(order);
                    saved = (saved) ? dishOrderRepository.LinkDishesToOrder(dishWithAmount, order) : true;
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();                    
                }
            }
            return saved;
        }
    }
}
