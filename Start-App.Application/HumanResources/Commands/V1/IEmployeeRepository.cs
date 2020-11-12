using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Start_App.Application.Common.Interfaces;
using Start_App.Application.Interface;
using Start_App.Domain.Entities;
using Start_App.Domain.Events;

namespace Start_App.Application.V1.Interface
{
    public interface IEmployeeRepository : IService<Employee>
    {

    }
    public class CreateEmployeeCommand : IRequest<int>
    {
        public int BusinessEntityId { get; set; }
        public string NationalIdnumber { get; set; }
        public string LoginId { get; set; }
        public short? OrganizationLevel { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public bool? SalariedFlag { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public bool? CurrentFlag { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateEmployeeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = new Employee
            {
                BirthDate = request.BirthDate
            };
            entity.DomainEvents.Add(new EmployeeCreatedEvent(entity));
            _context.Employees.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.BusinessEntityId;
        }
    }
}
