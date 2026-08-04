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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(category => category.Id);

            builder.Property(category => category.Id)
                .ValueGeneratedOnAdd();

            builder.Property(category => category.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(category => category.Name)
                .IsUnique()
                .HasDatabaseName("UQ_Categories_Name");

            builder.Property(category => category.Description)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(category => category.CreatedAt)
                .HasColumnType("datetime2")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();

            builder.Property(category => category.UpdatedAt)
                .HasColumnType("datetime2")
                .IsRequired(false);
        }
    }
}
