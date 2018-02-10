using Fos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Repositories.Contracts
{
    public interface IOrderRepository
    {
        bool CreateOrder(IDictionary<int, int> dishWithAmount, Client client, DinnerTable dinnerTable);
        bool UpdateOrder(Order order, IDictionary<int, int> dishWithAmount, DinnerTable dinnerTable);
        bool RemoveOrder(int id);
        bool RemoveOrder(Order order);
        Order Get(int id);
    }
}
