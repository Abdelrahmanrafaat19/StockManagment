using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagment.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Infrastructure.Configrations
{
    public class WorkHouseConfiguration : IEntityTypeConfiguration<WorkHouse>
    {
        public void Configure(EntityTypeBuilder<WorkHouse> builder)
        {
            builder.ToTable("WorkHouses");
            builder.HasKey(w => w.Id);
            builder.HasIndex(w => w.Name)
                   .IsUnique(); 
            builder.Property(w => w.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(w => w.Description)
                   .HasMaxLength(200);
            builder.Property(w => w.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");
            builder.Property(w => w.UpdatedAt)
                   .IsRequired(false);
           
        }
    }
}
