using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Start_App.Application.V2.Interface;
using Start_App.Domain.Common;
using Microsoft.Extensions.Logging;
using Start_App.Domain.Entities;
using Start_App.Domain.Requests;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Start_App.Domain.Dtos;

namespace Start_App.Infrastructure.V2.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AdventureWorks2017Context _context;
        private readonly ILogger<EmployeeRepository> _logger;
        private readonly IMapper _mapper;

        public EmployeeRepository(AdventureWorks2017Context context,
            ILogger<EmployeeRepository> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
        }

        public Employee Add(Employee entityToAdd)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> AddAsync(Employee entityToAdd)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Employee Details(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> DetailsAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExistsAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Employee>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Employee GetEmployeeById(int Id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.BusinessEntityId == Id);
            return employee;
        }

        public PagedList<EmployeeDto> GetEmployees(EmployeeRequest request)
        {
            var employeesQuery = _context.Employees.AsNoTracking();
            int total = employeesQuery.Count();
            var data = employeesQuery.Skip(request.PageIndex * request.PageSize).Take(request.PageSize).ToList();
            var list = new PagedList<Employee>(data, total, request.PageIndex, request.PageSize);
            var dtos = _mapper.Map<PagedList<EmployeeDto>>(list);
            return dtos;
        }

        public PagedList<Employee> GetPagedAll(IPagedRequestBase request)
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedList<Employee>> GetPagedAllAsync(IPagedRequestBase request)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges(string message)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveChangesAsync(string message)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(int id, Employee entityToUpdate)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, Employee entityToUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}
