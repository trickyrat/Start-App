/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Start_App.Domain.Entities;

namespace Start_App.Infrastructure.Persistence.Configurations.Production
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {

            builder.ToTable("ProductCategory", "Production");
            builder.Ignore(e => e.DomainEvents);
            builder.HasComment("High-level product categorization.");

            builder.HasIndex(e => e.Name, "AK_ProductCategory_Name")
                .IsUnique();

            //builder.HasIndex(e => e.Rowguid, "AK_ProductCategory_rowguid")
            //    .IsUnique();

            builder.Property(e => e.ProductCategoryId)
                .HasColumnName("ProductCategoryID")
                .HasComment("Primary key for ProductCategory records.");

            builder.Property(e => e.LastModified)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Category description.");

            //builder.Property(e => e.Rowguid)
            //    .HasColumnName("rowguid")
            //    .HasDefaultValueSql("(newid())")
            //    .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");
        }
    }
}
