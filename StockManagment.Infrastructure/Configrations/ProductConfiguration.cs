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
    public class ProductConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("Products", t =>
            {
                t.HasCheckConstraint("CK_Products_UnitPrice", "[UnitePrice] >= 0");
            });
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Category)
                   .WithMany()
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasIndex(p => p.ProductCode)
               .IsUnique()
               .HasDatabaseName("UQ_Products_SKU");
            builder.Property(c => c.ProductName).HasColumnType("NVARCHAR(100)");
            builder.Property(c => c.Description).HasColumnType("NVARCHAR(200)");
            builder.Property(propertyExpression: c => c.UnitePrice).HasColumnType("DECIMAL(18,2)");
            builder.Property(c => c.UnitOfMeasure).HasColumnType("NVARCHAR(50)");
            builder.Property(p => p.UnitOfMeasure)
                      .IsRequired()
                      .HasMaxLength(20)
                      .HasDefaultValue("pcs");
            builder.Property(p => p.IsActive)
                     .HasDefaultValue(true);

        }
    }
}
