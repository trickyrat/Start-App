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
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;
using Start_App.Application.Helpers;

namespace Start_App.Application.HumanResources.Queries.V1.GetEmployeesWithPagination
{
    public class GetEmployeesWithPaginationQuery : IRequest<PagedList<EmployeeDto>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public string FilterColumn { get; set; }
        public string FilterQuery { get; set; }

    }

    public class GetEmployeesWithPaginationQueryHandler : IRequestHandler<GetEmployeesWithPaginationQuery, PagedList<EmployeeDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetEmployeesWithPaginationQueryHandler> _logger;

        public GetEmployeesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetEmployeesWithPaginationQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<PagedList<EmployeeDto>> Handle(GetEmployeesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Employees.AsNoTracking().ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider);      
            if (!string.IsNullOrEmpty(request.FilterColumn) &&
                !string.IsNullOrEmpty(request.FilterQuery)
                && CheckPropertyHelper<EmployeeDto>.IsValidProperty(request.FilterColumn))
            {
                query = query.Where(string.Format("{0}.Contains(@0)", request.FilterColumn), request.FilterQuery);
            }
            if (!string.IsNullOrEmpty(request.SortColumn) && CheckPropertyHelper<EmployeeDto>.IsValidProperty(request.SortColumn))
            {
                string sortOrder = !string.IsNullOrEmpty(request.SortOrder)
                    && request.SortOrder.ToUpper() == "ASC"
                    ? "ASC"
                    : "DESC";
                query = query.OrderBy(string.Format("{0} {1}", request.SortColumn, sortOrder));
            }
            return await query.PagedListAsync(request.PageIndex, request.PageSize);
        }
    }
}
