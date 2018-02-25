using Fos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Repositories.Contracts
{
    public interface IDishesRepository
    {
        IList<Dish> GetAll();
        void Delete(int id);
        void Add(Dish dish);
        void Update(int id, string description, double price, int kitchenId, string imageUrl = null);
        /// <summary>
        /// Gets the dish or null if none found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Dish Get(int id);

        /// <summary>
        /// A dicationary with all the dishes that are not exhausted grouped by kitchen
        /// </summary>
        /// <returns></returns>
        IDictionary<Kitchen, List<Dish>> GetAllAvailableGroupedByKitchen();

        /// <summary>
        /// A dictionary with all the dishes and loaded dish orders grouped by kitchen
        /// </summary>
        /// <returns></returns>
        IDictionary<Kitchen, List<Dish>> GetAllGroupedByKitchenWithDishOrders();

        /// <summary>
        /// Syncs the exhausted dishes depending with the dishes with ids from parameter
        /// </summary>
        /// <param name="exhaustedDishIds">A list of the new exhausted dish ids</param>
        /// <returns>True if updated</returns>
        bool SyncExhausted(IEnumerable<int> exhaustedDishIds);
    }
}
