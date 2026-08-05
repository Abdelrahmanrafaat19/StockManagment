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
    public class StockItemConfiguration : IEntityTypeConfiguration<StockItems>
    {
        public void Configure(EntityTypeBuilder<StockItems> builder)
        {
            builder.ToTable("StockItems");

            builder.HasKey(s => s.Id);


            builder.Property(s => s.UpdateDate)
                .HasDefaultValueSql("SYSUTCDATETIME()");

            // Enforces "one quantity row per product per warehouse" at the DB level.
            builder.HasIndex(s => new { s.ProductsId, s.WorkHouseId })
                .IsUnique()
                .HasDatabaseName("UQ_StockItems_Product_Warehouse");

            builder.HasIndex(s => s.WorkHouseId)
                .HasDatabaseName("IX_StockItems_WarehouseId");

            builder.HasOne(s => s.Products)
                .WithMany()
                .HasForeignKey(s => s.ProductsId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.workHouse)
                .WithMany()
                .HasForeignKey(s => s.WorkHouseId);
        }


    }
}
