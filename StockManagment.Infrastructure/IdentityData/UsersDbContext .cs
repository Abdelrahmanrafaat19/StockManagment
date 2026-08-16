using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Infrastructure.IdentityData
{
    public class UsersDbContext : IdentityDbContext<ApplictionUser>
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        override protected void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplictionUser>(entity =>
            {
                entity.ToTable(name: "Users");
            });
            base.OnModelCreating(builder);
            //builder.ApplyConfigurationsFromAssembly(typeof(UsersDbContext).Assembly);

        }
    }
}
