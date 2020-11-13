/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Start_App.Application.Common.Interfaces;
using Start_App.Domain.Entities;
using Start_App.Domain.Events;

namespace Start_App.Application.HumanResources.Commands.V1.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public int BusinessEntityId { get; set; }
        public string Name { get; set; }
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

            };

            entity.DomainEvents.Add(new EmployeeCreatedEvent(entity));
            _context.Employees.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.BusinessEntityId;
        }
    }
}
