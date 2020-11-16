/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Start_App.Domain.Entities;

namespace Start_App.Infrastructure.Persistence.Configurations.Production
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", "Production");
            builder.Ignore(e => e.DomainEvents);
            builder.HasComment("Products sold or used in the manfacturing of sold products.");

            builder.HasIndex(e => e.Name, "AK_Product_Name")
                .IsUnique();

            builder.HasIndex(e => e.ProductNumber, "AK_Product_ProductNumber")
                .IsUnique();

            //builder.HasIndex(e => e.Rowguid, "AK_Product_rowguid")
            //    .IsUnique();

            builder.Property(e => e.ProductId)
                .HasColumnName("ProductID")
                .HasComment("Primary key for Product records.");

            builder.Property(e => e.Class)
                .HasMaxLength(2)
                .IsFixedLength(true)
                .HasComment("H = High, M = Medium, L = Low");

            builder.Property(e => e.Color)
                .HasMaxLength(15)
                .HasComment("Product color.");

            builder.Property(e => e.DaysToManufacture).HasComment("Number of days required to manufacture the product.");

            builder.Property(e => e.DiscontinuedDate)
                .HasColumnType("datetime")
                .HasComment("Date the product was discontinued.");

            builder.Property(e => e.FinishedGoodsFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Product is not a salable item. 1 = Product is salable.");

            builder.Property(e => e.ListPrice)
                .HasColumnType("money")
                .HasComment("Selling price.");

            builder.Property(e => e.MakeFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Product is purchased, 1 = Product is manufactured in-house.");

            builder.Property(e => e.LastModified)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Name of the product.");

            builder.Property(e => e.ProductLine)
                .HasMaxLength(2)
                .IsFixedLength(true)
                .HasComment("R = Road, M = Mountain, T = Touring, S = Standard");

            builder.Property(e => e.ProductModelId)
                .HasColumnName("ProductModelID")
                .HasComment("Product is a member of this product model. Foreign key to ProductModel.ProductModelID.");

            builder.Property(e => e.ProductNumber)
                .IsRequired()
                .HasMaxLength(25)
                .HasComment("Unique product identification number.");

            builder.Property(e => e.ProductSubcategoryId)
                .HasColumnName("ProductSubcategoryID")
                .HasComment("Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. ");

            builder.Property(e => e.ReorderPoint).HasComment("Inventory level that triggers a purchase order or work order. ");

            //builder.Property(e => e.Rowguid)
            //    .HasColumnName("rowguid")
            //    .HasDefaultValueSql("(newid())")
            //    .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            builder.Property(e => e.SafetyStockLevel).HasComment("Minimum inventory quantity. ");

            builder.Property(e => e.SellEndDate)
                .HasColumnType("datetime")
                .HasComment("Date the product was no longer available for sale.");

            builder.Property(e => e.SellStartDate)
                .HasColumnType("datetime")
                .HasComment("Date the product was available for sale.");

            builder.Property(e => e.Size)
                .HasMaxLength(5)
                .HasComment("Product size.");

            builder.Property(e => e.SizeUnitMeasureCode)
                .HasMaxLength(3)
                .IsFixedLength(true)
                .HasComment("Unit of measure for Size column.");

            builder.Property(e => e.StandardCost)
                .HasColumnType("money")
                .HasComment("Standard cost of the product.");

            builder.Property(e => e.Style)
                .HasMaxLength(2)
                .IsFixedLength(true)
                .HasComment("W = Womens, M = Mens, U = Universal");

            builder.Property(e => e.Weight)
                .HasColumnType("decimal(8, 2)")
                .HasComment("Product weight.");

            builder.Property(e => e.WeightUnitMeasureCode)
                .HasMaxLength(3)
                .IsFixedLength(true)
                .HasComment("Unit of measure for Weight column.");

            builder.HasOne(d => d.ProductModel)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductModelId);

            builder.HasOne(d => d.ProductSubcategory)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductSubcategoryId);

            builder.HasOne(d => d.SizeUnitMeasureCodeNavigation)
                .WithMany(p => p.ProductSizeUnitMeasureCodeNavigations)
                .HasForeignKey(d => d.SizeUnitMeasureCode);

            builder.HasOne(d => d.WeightUnitMeasureCodeNavigation)
                .WithMany(p => p.ProductWeightUnitMeasureCodeNavigations)
                .HasForeignKey(d => d.WeightUnitMeasureCode);
        }
    }
}
