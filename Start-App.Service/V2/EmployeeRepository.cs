using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Start_App.Domain.Entities;
using Start_App.Domain.Context;
using Start_App.Domain.RquestParameter;
using Start_App.Helper;

namespace Start_App.Service.V2
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

        public Employee GetEmployeeById(int Id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.BusinessEntityId == Id);
            return employee;
        }

        public PagedList<Employee> GetEmployees(EmployeeRequest request)
        {
            var employeesQuery = _context.Employees.AsNoTracking();
            int total = employeesQuery.Count();
            var data = employeesQuery.Skip(request.PageIndex * request.PageSize).Take(request.PageSize).ToList();
            var list = new PagedList<Employee>(data, total, request.PageIndex, request.PageSize);
            return list;
        }

    }
}
