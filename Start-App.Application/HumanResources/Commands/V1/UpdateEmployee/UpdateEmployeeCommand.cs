/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Start_App.Application.Common.Exceptions;
using Start_App.Application.Common.Interfaces;
using Start_App.Domain.Entities;

namespace Start_App.Application.HumanResources.Commands.V1.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest
    {
        public int BusinessEntityId { get; set; }

        public string JobTitle { get; set; }

        public DateTime BirthDate { get; set; }

        public string MaritalStatus { get; set; }

        public string Gender { get; set; }
    }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateEmployeeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employees.FindAsync(request.BusinessEntityId);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Employee), request.BusinessEntityId);
            }
            entity.JobTitle = request.JobTitle;
            entity.BirthDate = request.BirthDate;
            entity.MaritalStatus = request.MaritalStatus;
            entity.Gender = request.Gender;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
