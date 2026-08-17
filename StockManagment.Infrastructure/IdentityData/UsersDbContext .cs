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
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        override protected void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            base.OnModelCreating(builder);
            //builder.ApplyConfigurationsFromAssembly(typeof(UsersDbContext).Assembly);

        }
    }
}
