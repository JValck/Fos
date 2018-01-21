using Fos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Repositories.Contracts
{
    public interface IClientRepository
    {
        Client Create(string name, DinnerTable table, ApplicationUser applicationUser);

        /// <summary>
        /// Searches for a string pattern in the name
        /// </summary>
        /// <param name="nameContains">Pattern</param>
        /// <returns></returns>
        Client Search(string nameContains);

        IList<Client> GetAll();
    }
}
