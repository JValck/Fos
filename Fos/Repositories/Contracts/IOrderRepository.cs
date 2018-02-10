using Fos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Repositories.Contracts
{
    public interface IOrderRepository
    {
        bool CreateOrder(int[] dishWithAmount, Client client, DinnerTable dinnerTable);
        bool UpdateOrder(int[] dishWithAmount, Client client, DinnerTable dinnerTable);
        bool RemoveOrder(int id);
        bool RemoveOrder(Order order);
    }
}
