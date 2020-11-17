/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Start_App.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Start_App.Application.HumanResources.Queries.V1.GetEmployee
{
    public class GetEmployeeDetailQuery : IRequest<EmployeeDetailDto>
    {
        public int Id { get; set; }
    }

    public class GetEmployeeDetailQueryHandler : IRequestHandler<GetEmployeeDetailQuery, EmployeeDetailDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetEmployeeDetailQueryHandler> _logger;

        public GetEmployeeDetailQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetEmployeeDetailQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<EmployeeDetailDto> Handle(GetEmployeeDetailQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees.ProjectTo<EmployeeDetailDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
        }
    }
}
