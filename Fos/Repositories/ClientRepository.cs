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
        private readonly IStatusRepository statusRepository;

        public ClientRepository(ApplicationDbContext dbContext, IStatusRepository statusRepository)
        {
            this.dbContext = dbContext;
            this.statusRepository = statusRepository;
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

        public bool UpdateTable(Client client, DinnerTable newTable)
        {
            var dinnerTableClient = dbContext.DinnerTableClients.Where(dtc => dtc.ClientId == client.Id && dtc.DinnerTableId == newTable.Id).FirstOrDefault();
            if(dinnerTableClient != null)
            {
                dinnerTableClient.IsCurrent = true;
            }
            else
            {
                client.DinnerTableClients.Add(new DinnerTableClient
                {
                    Client = client,
                    DinnerTable = newTable
                });
            }
            return dbContext.SaveChanges() > 0;
        }

        public bool Delete(Client client)
        {
            dbContext.Clients.Remove(client);
            return dbContext.SaveChanges() > 0;
        }

        public bool Exists(int clientId)
        {
            return (Get(clientId) != null);
        }

        public Client Get(int id)
        {
            return dbContext.Clients
                .Include(c => c.DinnerTableClients).ThenInclude(dtc => dtc.DinnerTable)
                .FirstOrDefault(c => c.Id == id);
        }

        public IList<Client> GetAll()
        {
            return dbContext.Clients
                .Include(c => c.DinnerTableClients).ThenInclude(dtc => dtc.DinnerTable)
                .ToList();
        }

        public IList<Client> GetAllThatRequirePayment()
        {
            return dbContext.Clients
                .Include(c => c.Orders)
                .Include(c => c.DinnerTableClients).ThenInclude(dtc => dtc.DinnerTable)
                .Where(c => c.Orders.Where(o => o.Status != statusRepository.GetPayedStatus()).Count() > 0)
                .ToList();
        }

        public Client Search(string nameContains)
        {
            return dbContext.Clients.Where(c => c.Name.Contains(nameContains)).FirstOrDefault();
        }
    }
}
