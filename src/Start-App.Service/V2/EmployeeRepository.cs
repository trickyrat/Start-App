using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Start_App.Data.Models;
using Start_App.Domain.Entities;
using Start_App.Domain.RquestParameter;
using Start_App.Helper;

namespace Start_App.Service.V2
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
            var employee = _context.Employee.SingleOrDefault(x => x.BusinessEntityId == Id);
            return employee;
        }

        public PagedList<Employee> GetEmployees(EmployeeRequest request)
        {
            var employeesQuery = _context.Employee.AsQueryable();
            int total = employeesQuery.Count();
            var data = employeesQuery.ToList();
            var list = new PagedList<Employee>(data, total, request.PageIndex, request.PageSize);
            return list;
        }

    }
}
