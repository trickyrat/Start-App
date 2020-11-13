/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Start_App.Application.Common.Exceptions;
using Start_App.Application.Common.Interfaces;
using Start_App.Domain.Entities;

namespace Start_App.Application.HumanResources.Commands.V1.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int BusinessEntityId { get; set; }

    }

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteEmployeeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employees.FindAsync(request.BusinessEntityId);
            if(entity == null)
            {
                throw new NotFoundException(nameof(Employee), request.BusinessEntityId);
            }
            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
