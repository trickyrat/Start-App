using Start_App.Application.Interface;
using Start_App.Domain.Common;
using Start_App.Domain.Entities;
using Start_App.Domain.Requests;



namespace Start_App.Application.V2.Interface
{
    public interface IEmployeeRepository : IService<Employee>
    {
        PagedList<Employee> GetEmployees(EmployeeRequest request);

        Employee GetEmployeeById(int Id);
    }
}
