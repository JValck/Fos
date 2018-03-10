using Fos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Repositories.Contracts
{
    public interface IOrderRepository
    {
        bool CreateOrder(IDictionary<int, int> dishWithAmount, Client client, DinnerTable dinnerTable, ApplicationUser user);
        bool UpdateOrder(Order order, IDictionary<int, int> dishWithAmount, DinnerTable dinnerTable, ApplicationUser user);
        bool RemoveOrder(int id);
        bool RemoveOrder(Order order);
        Order Get(int id);
        IList<Order> GetOrdersForClient(Client client);
        Order Get(Order order);
        bool MarkAllOrdersAsPayedForClient(Client client);        
    }
}
