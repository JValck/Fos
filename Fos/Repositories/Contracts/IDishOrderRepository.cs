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
        /// <param name="amount">The amount of the dish</param>
        /// <returns>True if saved</returns>
        bool CreateForOrder(Order order, Dish dish, int amount);

        /// <summary>
        /// Removes a dish from the order
        /// </summary>
        /// <param name="order"></param>
        /// <param name="dish">The dish to remove</param>
        /// <returns>True if saved</returns>
        bool RemoveFromOrder(Order order, Dish dish);
        DishOrder Get(Order order, Dish dish);
        bool RemoveAllDishesFromOrder(Order order);

        /// <summary>
        /// Links the dishes and there amount to the order
        /// </summary>
        /// <param name="dishWithAmount">Dictionary with the dish id as key and the amount as value</param>
        /// <param name="order">The order where the dishes should be linked to</param>
        /// <returns></returns>
        bool LinkDishesToOrder(IDictionary<int, int> dishWithAmount, Order order);
    }
}
