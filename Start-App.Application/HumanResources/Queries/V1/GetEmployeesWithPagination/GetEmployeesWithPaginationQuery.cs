/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Start_App.Application.Common.Interfaces;
using Start_App.Application.Common.Mappings;
using Start_App.Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Start_App.Application.HumanResources.Queries.V1.GetEmployeesWithPagination
{
    public class GetEmployeesWithPaginationQuery : IRequest<PagedList<EmployeeDto>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public string SearchTerm { get; set; }

    }

    public class GetEmployeesWithPaginationQueryHandler : IRequestHandler<GetEmployeesWithPaginationQuery, PagedList<EmployeeDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetEmployeesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PagedList<EmployeeDto>> Handle(GetEmployeesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Employees.AsNoTracking();
            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(x => x.JobTitle.Contains(request.SearchTerm));
            }
            return await query.OrderBy(e => e.BusinessEntityId)
                .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                .PagedListAsync(request.PageIndex, request.PageSize);
        }
    }
}
