using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Fos.Models;

namespace Fos.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<DinnerTable> DinnerTables { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }
        public DbSet<DishOrder> DishOrders { get; set; }
        public DbSet<DinnerTableClient> DinnerTableClients { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<DinnerTableClient>().HasKey(d => new { d.ClientId, d.DinnerTableId });
            builder.Entity<DishOrder>().HasKey(d => new { d.DishId, d.OrderId });
            builder.Entity<Status>().HasIndex(s => new { s.Code }).IsUnique();
        }
    }
}
