using Fos.Data;
using Fos.Models;
using Fos.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationDbContext dbContext;

        public StatusRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Status GetCompletedStatus()
        {
            return dbContext.Statuses.Where(s => s.Code == "C").First();
        }

        public Status GetIncludedStatus()
        {
            return dbContext.Statuses.Where(s => s.Code == "I").First();
        }

        public Status GetPayedStatus()
        {
            return dbContext.Statuses.Where(s => s.Code == "P").First();
        }

        public Status GetUpdatedStatus()
        {
            return dbContext.Statuses.Where(s => s.Code == "U").First();
        }
    }
}
