// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using System.Collections.Generic;
using System.Threading.Tasks;
using Start_App.Domain.Entities;
using Start_App.Domain.RquestParameter;

namespace Start_App.Service
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(int? companyId);

        Task<Employee> GetEmployeeAsync(int? companyId, int? employeeId);
        Task<IEnumerable<Employee>> GetEmployeesByNameAsync(int? companyId, string employeeName);

        void AddEmployee(int? companyId, Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Task<IEnumerable<Company>> GetCompaniesAsync(CompanyRequest request);
        Task<Company> GetCompanyAsync(int? companyId);
        Task<IEnumerable<Company>> GetCompaniesByNameAsync(string companyName);

        Company AddCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);
        Task<bool> CompanyExistsAsync(int? companyId);
        Task<bool> SaveAsync();
    }
}
