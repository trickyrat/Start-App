using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Start_App.Data.Models;
using Start_App.Domain.Entities;
using Start_App.Domain.RquestParameter;
using Start_App.Helper;

namespace Start_App.V2.Service
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AdventureWorks2017Context _context;
        private readonly ILogger<EmployeeRepository> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public EmployeeRepository(AdventureWorks2017Context context,
            ILogger<EmployeeRepository> logger,
            IHttpClientFactory clientFactory)
        {
            _context = context;
            _logger = logger;
        }

        public Employee GetEmployeeById(int Id)
        {
            var employee = _context.Employee.Find(Id);
            return employee;
        }

        public PagedList<Employee> GetEmployees(EmployeeRequest request)
        {
            var employeesQuery = _context.Employee.AsQueryable();
            var employees = PagedList<Employee>.Create(employeesQuery,
                request.PageIndex,
                request.PageSize,
                request.SortColumn,
                request.SortOrder,
                request.FilterColumn,
                request.FilterQuery);
            return employees;
        }

    }
}
