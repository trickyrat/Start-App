/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Start_App.Domain.Entities;

namespace Start_App.Infrastructure.Persistence.Configurations.HumanResources
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.HasKey(e => e.BusinessEntityId)
                .HasName("PK_Employee_BusinessEntityID");

            builder.ToTable("Employee", "HumanResources");

            builder.HasComment("Employee information such as salary, department, and title.");

            builder.HasIndex(e => e.LoginId, "AK_Employee_LoginID")
                .IsUnique();

            builder.HasIndex(e => e.NationalIdnumber, "AK_Employee_NationalIDNumber")
                .IsUnique();

            builder.HasIndex(e => e.Rowguid, "AK_Employee_rowguid")
                .IsUnique();

            builder.Property(e => e.BusinessEntityId)
                .ValueGeneratedNever()
                .HasColumnName("BusinessEntityID")
                .HasComment("Primary key for Employee records.  Foreign key to BusinessEntity.BusinessEntityID.");

            builder.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasComment("Date of birth.");

            builder.Property(e => e.CurrentFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Inactive, 1 = Active");

            builder.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(1)
                .IsFixedLength(true)
                .HasComment("M = Male, F = Female");

            builder.Property(e => e.HireDate)
                .HasColumnType("date")
                .HasComment("Employee hired on this date.");

            builder.Property(e => e.JobTitle)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Work title such as Buyer or Sales Representative.");

            builder.Property(e => e.LoginId)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnName("LoginID")
                .HasComment("Network login.");

            builder.Property(e => e.MaritalStatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsFixedLength(true)
                .HasComment("M = Married, S = Single");

            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder.Property(e => e.NationalIdnumber)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("NationalIDNumber")
                .HasComment("Unique national identification number such as a social security number.");

            builder.Property(e => e.OrganizationLevel)
                .HasComputedColumnSql("([OrganizationNode].[GetLevel]())", false)
                .HasComment("The depth of the employee in the corporate hierarchy.");

            builder.Property(e => e.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            builder.Property(e => e.SalariedFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("Job classification. 0 = Hourly, not exempt from collective bargaining. 1 = Salaried, exempt from collective bargaining.");

            builder.Property(e => e.SickLeaveHours).HasComment("Number of available sick leave hours.");

            builder.Property(e => e.VacationHours).HasComment("Number of available vacation hours.");

            builder.HasOne(d => d.BusinessEntity)
                .WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);


        }
    }
}
