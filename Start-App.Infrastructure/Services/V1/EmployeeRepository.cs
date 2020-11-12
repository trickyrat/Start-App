// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Start_App.Application.V1.Interface;
using Start_App.Domain.Common;
using Start_App.Domain.Entities;

namespace Start_App.Application.Services.V1.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AdventureWorks2017Context _context;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(AdventureWorks2017Context context,
            ILogger<EmployeeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Employee> AddAsync(Employee entityToAdd)
        {
            _logger.LogInformation($"Employee request parameters: {JsonSerializer.Serialize(entityToAdd)}");
            var entity = await _context.Employees.AddAsync(entityToAdd);
            await SaveChangesAsync("employee created.");
            return entity.Entity;
        }

        public Employee Add(Employee entityToAdd)
        {
            _logger.LogInformation($"Employee request parameters: {JsonSerializer.Serialize(entityToAdd)}");
            var entity = _context.Employees.Add(entityToAdd);
            SaveChanges("employee created.");
            return entity.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee is null)
            {
                return false;
            }
            _context.Employees.Remove(employee);
            await SaveChangesAsync("employee deleted.");
            return true;
        }

        public bool Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee is null)
            {
                return false;
            }
            _context.Employees.Remove(employee);
            SaveChanges("employee deleted.");
            return true;
        }

        public async Task<bool> UpdateAsync(int id, Employee entityToUpdate)
        {
            entityToUpdate.ModifiedDate = DateTime.Now;
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public bool Update(int id, Employee entityToUpdate)
        {
            entityToUpdate.ModifiedDate = DateTime.Now;
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }


        public async Task<Employee> DetailsAsync(int id)
        {
            _logger.LogInformation($"Employee EntityBusinessId: {id}");
            var employee = await _context.Employees.SingleOrDefaultAsync(x => x.BusinessEntityId == id);
            return employee;
        }

        public Employee Details(int id)
        {
            _logger.LogInformation($"Employee EntityBusinessId: {id}");
            var employee = _context.Employees.SingleOrDefault(x => x.BusinessEntityId == id);
            return employee;
        }

        public async Task<PagedList<Employee>> GetPagedAllAsync(IPagedRequestBase request)
        {
            var employeesQuery = _context.Employees.AsNoTracking();
            int total = await employeesQuery.CountAsync();
            var data = await employeesQuery.Skip(request.PageIndex * request.PageSize).Take(request.PageSize).ToListAsync();
            var list = new PagedList<Employee>(data, total, request.PageIndex, request.PageSize);
            return list;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            var list = await _context.Employees.ToListAsync();
            return list;
        }

        public PagedList<Employee> GetPagedAll(IPagedRequestBase request)
        {
            var employeesQuery = _context.Employees.AsNoTracking();
            int total = employeesQuery.Count();
            var data = employeesQuery.Skip(request.PageIndex * request.PageSize).Take(request.PageSize).ToList();
            var list = new PagedList<Employee>(data, total, request.PageIndex, request.PageSize);
            return list;
        }

        public List<Employee> GetAll()
        {
            var list = _context.Employees.ToList();
            return list;
        }


        public async Task<bool> ExistsAsync(int id) => await _context.Employees.FindAsync(id) == null;

        public bool Exists(int id) => _context.Employees.Find(id) == null;

        public async Task SaveChangesAsync(string message)
        {
            var count = await _context.SaveChangesAsync();
            _logger.LogInformation($"{count} {message}");
        }

        public void SaveChanges(string message)
        {
            var count = _context.SaveChanges();
            _logger.LogInformation($"{message} {count}");
        }
    }
}
