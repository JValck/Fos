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
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ClientRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Client Create(string name, DinnerTable table)
        {
            var client = new Client
            {
                Name = name,
                DinnerTableClients = new List<DinnerTableClient>(),
            };
            client.DinnerTableClients.Add(new DinnerTableClient { DinnerTable = table});
            dbContext.Clients.Add(client);
            dbContext.SaveChanges();
            return client;
        }

        public bool Exists(int clientId)
        {
            return (Get(clientId) != null);
        }

        public Client Get(int id)
        {
            return dbContext.Clients
                .Include(c => c.DinnerTableClients).ThenInclude(dtc => dtc.DinnerTable)
                .First(c => c.Id == id);
        }

        public IList<Client> GetAll()
        {
            return dbContext.Clients
                .Include(c => c.DinnerTableClients).ThenInclude(dtc => dtc.DinnerTable)
                .ToList();
        }

        public Client Search(string nameContains)
        {
            return dbContext.Clients.Where(c => c.Name.Contains(nameContains)).FirstOrDefault();
        }
    }
}
