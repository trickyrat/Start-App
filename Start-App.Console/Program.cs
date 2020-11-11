using System;
using System.Collections.Generic;
using Start_App.Data;
using Start_App.Domain.Entities;

namespace Start_App.App
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Demo
    {
        private readonly SqlServerDbContext _context;

        public Demo(SqlServerDbContext context)
        {
            _context = context;
        }


        public void AddCompany()
        {
            Company company = new Company
            {
                Id = Guid.NewGuid(),
                Name = "test",
                Introduction = "This is a test company",
                Country = "China",
                Industry = "Internet",
                Product = "CDs"
            };
            _context.Companies.Add(company);

            int count  = _context.SaveChanges();
            Console.WriteLine(count);
        }


    }


}
