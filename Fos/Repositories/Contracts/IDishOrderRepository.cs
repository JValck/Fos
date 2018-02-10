using Fos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Repositories.Contracts
{
    public interface IDishOrderRepository
    {
        /// <summary>
        /// Creats a dish order
        /// </summary>
        /// <param name="order">The order to link to</param>
        /// <param name="dish">The dish to order</param>
        /// <returns>True if saved</returns>
        bool CreateForOrder(Order order, Dish dish);

        /// <summary>
        /// Removes a dish from the order
        /// </summary>
        /// <param name="order"></param>
        /// <param name="dish">The dish to remove</param>
        /// <returns>True if saved</returns>
        bool RemoveFromOrder(Order order, Dish dish);
    }
}
