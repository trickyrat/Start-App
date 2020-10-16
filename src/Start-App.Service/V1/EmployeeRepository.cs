using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Start_App.Data.Models;
using Start_App.Domain.Entities;
using Start_App.Domain.RquestParameter;
using Start_App.Helper;

namespace Start_App.Service.V1
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
            _clientFactory = clientFactory;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int Id)
        {
            var employee = await _context.Employee.SingleOrDefaultAsync(x => x.BusinessEntityId == Id);
            return employee;
        }

        public async Task<PagedList<Employee>> GetEmployeesAsync(EmployeeRequest request)
        {
            var employeesQuery = _context.Employee.AsQueryable();
            int total = await employeesQuery.CountAsync();
            var data = await employeesQuery.ToListAsync();
            var list = new PagedList<Employee>(data, total, request.PageIndex, request.PageSize);
            return list;
        }
    }
}
