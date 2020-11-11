// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Start_App.Domain.Context;
using Start_App.Domain.Entities;
using Start_App.Domain.RquestParameter;
using Start_App.Helper;

namespace Start_App.Service.V1
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

        public async Task<Employee> GetEmployeeByIdAsync(int Id)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(x => x.BusinessEntityId == Id);
            return employee;
        }

        public async Task<PagedList<Employee>> GetEmployeesAsync(EmployeeRequest request)
        {
            var employeesQuery = _context.Employees.AsNoTracking();
            int total = await employeesQuery.CountAsync();
            var data = await employeesQuery.Skip(request.PageIndex * request.PageSize).Take(request.PageSize).ToListAsync();
            var list = new PagedList<Employee>(data, total, request.PageIndex, request.PageSize);
            return list;
        }
    }
}
