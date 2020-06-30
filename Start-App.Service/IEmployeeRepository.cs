using System.Collections.Generic;
using System.Threading.Tasks;
using Start_App.Domain.Entities;
using Start_App.Domain.RquestParameter;
using Start_App.Helper;

namespace Start_App.Service
{
    public interface IEmployeeRepository
    {
        Task<PagedList<Employee>> GetEmployees(EmployeeRequest request);

        Task<Employee> GetEmployeeById(int Id);
    }
}
