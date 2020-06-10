// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Start_App.Data;
using Start_App.Domain.Entities;
using Start_App.Domain.RquestParameter;
using Start_App.Helper;

namespace Start_App.Service
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly SqlServerDbContext _context;

        public CompanyRepository(SqlServerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Company AddCompany(Company company)
        {
            CheckHelper.ArgumentNullCheck(company);
            company.Id = Guid.NewGuid();
            if (company.Employees.Any())
            {
                foreach (var employee in company.Employees)
                {
                    employee.Id = Guid.NewGuid();
                }
            }
            var entity = _context.Companies.Add(company);
            return entity.Entity;
        }

        public void AddEmployee(Guid companyId, Employee employee)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            CheckHelper.ArgumentNullCheck(employee);
            employee.CompanyId = companyId;
            _context.Employees.Add(employee);
        }

        public async Task<bool> CompanyExistsAsync(Guid companyId)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            return await _context.Companies.AnyAsync(x => x.Id == companyId);
        }

        public void DeleteCompany(Company company)
        {
            CheckHelper.ArgumentNullCheck(company);
            _context.Companies.Remove(company);
        }

        public void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync(CompanyRequest request)
        {
            CheckHelper.ArgumentNullCheck(request);
            if (string.IsNullOrWhiteSpace(request.CompanyName) &&
                string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                return await _context.Companies.ToListAsync();
            }
            var queryExpression = _context.Companies as IQueryable<Company>;
            if (!string.IsNullOrWhiteSpace(request.CompanyName))
            {
                request.CompanyName = request.CompanyName.Trim();
                queryExpression = queryExpression.Where(x => x.Name == request.CompanyName);
            }
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                request.SearchTerm = request.SearchTerm.Trim();
                queryExpression = queryExpression.Where(x => x.Name.Contains(request.SearchTerm) ||
                    x.Introduction.Contains(request.SearchTerm));
            }

            return await queryExpression.ToListAsync();
        }

        public async Task<Company> GetCompanyAsync(Guid companyId)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            return await _context.Companies.FirstOrDefaultAsync(x => x.Id == companyId);
        }

        public async Task<IEnumerable<Company>> GetCompaniesByNameAsync(string companyName)
        {
            if (string.IsNullOrWhiteSpace(companyName))
            {
                throw new ArgumentNullException(nameof(companyName));
            }
            return await _context.Companies.Where(x => x.Name.Contains(companyName)).ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid employeeId)
        {
            if (employeeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            return await _context.Employees
                .Where(x => x.CompanyId == companyId && x.Id == employeeId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByNameAsync(Guid companyId, string employeeName)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            if (string.IsNullOrWhiteSpace(employeeName))
            {
                throw new ArgumentNullException(nameof(employeeName));
            }
            return await _context.Employees
                .Where(x => x.CompanyId == companyId && x.EmployeeName.Contains(employeeName)).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            return await _context.Employees
                .Where(x => x.CompanyId == companyId)
                .OrderBy(x => x.EmployeeNo)
                .ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }

        public void UpdateCompany(Company company)
        {
            CheckHelper.ArgumentNullCheck(company);
            _context.Companies.Update(company);
        }

        public void UpdateEmployee(Employee employee)
        {
            CheckHelper.ArgumentNullCheck(employee);
            _context.Employees.Update(employee);
        }
    }
}
