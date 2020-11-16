/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Start_App.Domain.Entities;

namespace Start_App.Infrastructure.Persistence.Configurations.Production
{
    public class ProductSubcategoryConfiguration : IEntityTypeConfiguration<ProductSubcategory>
    {
        public void Configure(EntityTypeBuilder<ProductSubcategory> builder)
        {
            builder.ToTable("ProductSubcategory", "Production");
            builder.Ignore(e => e.DomainEvents);
            builder.HasComment("Product subcategories. See ProductCategory table.");

            builder.HasIndex(e => e.Name, "AK_ProductSubcategory_Name")
                .IsUnique();

            //builder.HasIndex(e => e.Rowguid, "AK_ProductSubcategory_rowguid")
            //    .IsUnique();

            builder.Property(e => e.ProductSubcategoryId)
                .HasColumnName("ProductSubcategoryID")
                .HasComment("Primary key for ProductSubcategory records.");

            builder.Property(e => e.LastModified)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Subcategory description.");

            builder.Property(e => e.ProductCategoryId)
                .HasColumnName("ProductCategoryID")
                .HasComment("Product category identification number. Foreign key to ProductCategory.ProductCategoryID.");

            //builder.Property(e => e.Rowguid)
            //    .HasColumnName("rowguid")
            //    .HasDefaultValueSql("(newid())")
            //    .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            builder.HasOne(d => d.ProductCategory)
                .WithMany(p => p.ProductSubcategories)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
