using System.Threading.Tasks;
using Start_App.Data.Models;
using Start_App.Domain.Entities;
using Start_App.Domain.RquestParameter;
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

        public async Task<Employee> GetEmployeeById(int Id)
        {
            var employee = await _context.Employee.FindAsync(Id);// 使用FindAsync
            //var employee = _context.Employee.FirstOrDefaultAsync(x => x.BusinessEntityId == Id); // 使用FirstOrDefaultAsync
            //var employee = _context.Employee.FirstAsync(x => x.BusinessEntityId == Id); // 使用FirstAsync 但是查不到 则会抛异常 推荐使用上面两种
            return employee;
        }

        public async Task<PagedList<Employee>> GetEmployees(EmployeeRequest request)
        {
            var employeesQuery = _context.Employee.AsQueryable();
            var employees = await PagedList<Employee>.CreateAsync(employeesQuery,
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
