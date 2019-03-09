using Fos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Repositories.Contracts
{
    public interface IClientRepository
    {
        Client Create(string name, DinnerTable table);
        /// <summary>
        /// Updates the primary table of a client
        /// </summary>
        /// <param name="client">The client</param>
        /// <param name="newTable">The new table where future dishes should be delivered by default</param>
        /// <returns>True if saved</returns>
        bool UpdateTable(Client client, DinnerTable newTable);

        /// <summary>
        /// Searches for a string pattern in the name
        /// </summary>
        /// <param name="nameContains">Pattern</param>
        /// <returns></returns>
        Client Search(string nameContains);

        IList<Client> GetAll();
        bool Exists(int clientId);
        Client Get(int id);
        bool Delete(Client client);
        /// <summary>
        /// Retrieves a list of all the customers that have unpaied
        /// orders
        /// </summary>
        /// <returns></returns>
        IList<Client> GetAllThatRequirePayment();

        /// <summary>
        /// Rename a client
        /// </summary>
        /// <param name="id">The id of the client to rename</param>
        /// <param name="newName">The new name of the client</param>
        /// <returns>The updated client</returns>
        Client Rename(int id, string newName);
    }
}
