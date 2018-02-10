using Fos.Data;
using Fos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Seeders
{
    public class StatusSeeder
    {
        public static void Seed(ApplicationDbContext dbContext)
        {
            var statuses = dbContext.Statuses;
            if (!statuses.Where(s => s.Code == "I").Any())
            {
                statuses.Add(new Status { Code = "I", Description = "Opgenomen" });
            }
            if (!statuses.Where(s => s.Code == "U").Any())
            {
                statuses.Add(new Status { Code = "U", Description = "Aangepast" });
            }
            if (!statuses.Where(s => s.Code == "C").Any())
            {
                statuses.Add(new Status { Code = "C", Description = "Verwerkt" });
            }
            if (!statuses.Where(s => s.Code == "P").Any())
            {
                statuses.Add(new Status { Code = "P", Description = "Betaald" });
            }
            dbContext.SaveChanges();
        }
    }
}
