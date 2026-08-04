
using Microsoft.EntityFrameworkCore;
using StockManagment.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Infrastructure.Data
{
    public class StockManagmentDb : DbContext
    {
        public StockManagmentDb(DbContextOptions<StockManagmentDb> options) : base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StockManagmentDb).Assembly);
        }
        public DbSet<Category> Categories { get; set; } = default!;
    }
}
