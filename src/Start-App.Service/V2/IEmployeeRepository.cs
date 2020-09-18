using System.Threading.Tasks;
using Start_App.Domain.Entities;
using Start_App.Domain.RquestParameter;
using Start_App.Helper;

namespace Start_App.V2.Service
{
    public interface IEmployeeRepository
    {
        PagedList<Employee> GetEmployees(EmployeeRequest request);

        Employee GetEmployeeById(int Id);
    }
}
