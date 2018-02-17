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
    public class DishesRepository:IDishesRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DishesRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Dish dish)
        {
            dbContext.Dishes.Add(dish);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = Get(id);
            if(obj != null)
            {
                dbContext.Dishes.Remove(obj);
                dbContext.SaveChanges();
            }
        }

        public Dish Get(int id)
        {
            return dbContext.Dishes.Where(d => d.Id == id).FirstOrDefault();
        }

        public IList<Dish> GetAll()
        {
            return dbContext.Dishes
                .Include(d => d.Kitchen)
                .ToList();
        }

        public IDictionary<Kitchen, List<Dish>> GetAllAvailableGroupedByKitchen()
        {
            var all = GetAll();
            return all.Where(d => !d.Exhausted).GroupBy(d => d.Kitchen).ToDictionary(g => g.Key, g => g.ToList());
        }

        public void Update(int id, string description, double price, int kitchenId, string imageUrl = null)
        {
            var obj = Get(id);
            if(obj != null)
            {
                obj.Description = description;
                obj.Price = price;
                obj.ImageUrl = imageUrl;
                obj.KitchenId = kitchenId;
                dbContext.Update(obj);
                dbContext.SaveChanges();
            }
        }
    }
}
