using Fos.Data;
using Fos.Models;
using Fos.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Repositories
{
    public class DinnerTableRepository: IDinnerTableRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DinnerTableRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<DinnerTable> GetAll()
        {
            return dbContext.DinnerTables.ToList();
        }
    }
}
