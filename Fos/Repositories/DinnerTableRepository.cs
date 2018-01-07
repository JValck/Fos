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

        public void CreateInterval(int from, int until)
        {
            for(var tableNumber = from; tableNumber <= until; tableNumber++)
            {
                if (!Exists(tableNumber))
                {
                    dbContext.DinnerTables.Add(new DinnerTable
                    {
                        TableNumber = tableNumber
                    });
                }
            }
            dbContext.SaveChanges();
        }

        public void Delete(Guid guid)
        {
            var toRemove = dbContext.DinnerTables.Find(guid);
            dbContext.DinnerTables.Remove(toRemove);
            dbContext.SaveChanges();
        }

        public bool Exists(int tableNumber)
        {
            return dbContext.DinnerTables.Where(t => t.TableNumber == tableNumber).Count() > 0;
        }

        public IList<DinnerTable> GetAll()
        {
            return dbContext.DinnerTables.ToList();
        }
    }
}
