// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using System;
using Microsoft.EntityFrameworkCore;
using Start_App.Domain.Entities;
using Start_App.Domain.Enums;
using Start_App.Domains.Entities;

namespace Start_App.Data
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().Property(x => x.CompanyName).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Employee>().Property(x => x.EmployeeNo).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Employee>().Property(x => x.EmployeeName).IsRequired().HasMaxLength(50);

            //modelBuilder.Entity<Employee>()
            //    .HasOne(x => x.Company)
            //    .WithMany(x => x.Employees)
            //    .HasForeignKey(x => x.CompanyId)
            //    .OnDelete(DeleteBehavior.Restrict);  // company -> employees 1:n

            //modelBuilder.Entity<City>()
            //    .HasOne(x => x.Province)
            //    .WithMany(x => x.Cities)
            //    .HasForeignKey(x => x.ProvinceCode)
            //    .OnDelete(DeleteBehavior.Restrict);  // province -> cities 1:n

            //modelBuilder.Entity<Area>()
            //    .HasOne(x => x.City)
            //    .WithMany(x => x.Areas)
            //    .HasForeignKey(x => x.CityCode); // city -> areas 1:n

            //modelBuilder.Entity<Street>()
            //    .HasOne(x => x.Area)
            //    .WithMany(x => x.Streets)
            //    .HasForeignKey(x => x.AreaCode);  // area -> streets 1:n


        }

        public DbSet<Person> People { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Street> Streets { get; set; }
    }
}
