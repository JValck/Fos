using Fos.Data;
using Fos.Models;
using Fos.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Repositories
{
    public class KitchenRepository : IKitchenRepository
    {
        private readonly ApplicationDbContext dbContext;

        public KitchenRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Kitchen kitchen)
        {
            dbContext.Kitchens.Add(kitchen);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var toRemove = Get(id);
            if(toRemove != null)
            {
                dbContext.Kitchens.Remove(toRemove);
                dbContext.SaveChanges();
            }
        }

        public Kitchen Get(int id)
        {
            return dbContext.Kitchens.Where(k =>k.Id == id).FirstOrDefault();
        }

        public IList<Kitchen> GetAll()
        {
            return dbContext.Kitchens.ToList();
        }

        public void UpdateKitchenName(int id, string name)
        {
            var kitchen = Get(id);
            if(kitchen != null)
            {
                kitchen.Name = name;
                dbContext.Update(kitchen);                
                dbContext.SaveChanges();
            }
        }


    }
}
