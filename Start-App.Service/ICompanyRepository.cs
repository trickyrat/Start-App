using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Start_App.Domain.Entities;

namespace Start_App.Service
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId);
        // IAsyncEnumerable<Employee> GetEmployeesAsync(Guid companyId);

        Task<Employee> GetEmployeeAsync(Guid companyId, Guid employeeId);
        Task<IEnumerable<Employee>> GetEmployeesByNameAsync(Guid companyId, string employeeName);

        void AddEmployee(Guid companyId, Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Task<IEnumerable<Company>> GetCompaniesAsync();
        Task<Company> GetCompanyAsync(Guid companyId);
        Task<IEnumerable<Company>> GetCompaniesByNameAsync(string companyName);

        void AddCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);
        Task<bool> CompanyExistsAsync(Guid companyId);
        Task<bool> SaveAsync();
    }
}
