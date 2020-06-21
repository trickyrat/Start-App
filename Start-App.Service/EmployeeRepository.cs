using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Start_App.Data.Models;
using Start_App.Domain.Entities;
using Start_App.Helper;

namespace Start_App.Service
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AdventureWorks2017Context _context;

        public EmployeeRepository(AdventureWorks2017Context context)
        {
            _context = context;
        }
        public async Task<PagedList<Employee>> GetEmployees(int pageIndex, int pageSize)
        {
            var employeesQuery = _context.Employee.AsQueryable();
            var employees = await PagedList<Employee>.CreateAsync(employeesQuery, pageIndex, pageSize);
            return employees;
        }
    }
}
