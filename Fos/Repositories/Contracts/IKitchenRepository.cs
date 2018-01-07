using Fos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Repositories.Contracts
{
    public interface IKitchenRepository
    {
        IList<Kitchen> GetAll();
        void Delete(int id);
        void Add(Kitchen kitchen);
        void UpdateKitchenName(int id, string name);
        /// <summary>
        /// Get the kitchen for the given id or NULL if none found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Kitchen Get(int id);
    }
}
