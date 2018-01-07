﻿using Fos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Repositories.Contracts
{
    public interface IDishesRepository
    {
        IList<Dish> GetAll();
        void Delete(int id);
        void Add(Dish dish);
        void Update(int id, string description, double price);
        /// <summary>
        /// Gets the dish or null if none found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Dish Get(int id);
    }
}
