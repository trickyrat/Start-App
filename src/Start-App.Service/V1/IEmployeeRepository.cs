using System.Threading.Tasks;
using Start_App.Domain.Entities;
using Start_App.Domain.RquestParameter;
using Start_App.Helper;

namespace Start_App.V1.Service
{
    public interface IEmployeeRepository
    {
        Task<PagedList<Employee>> GetEmployeesAsync(EmployeeRequest request);

        Task<Employee> GetEmployeeByIdAsync(int Id);
    }
}
