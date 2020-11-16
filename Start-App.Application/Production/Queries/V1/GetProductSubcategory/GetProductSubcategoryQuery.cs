/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

using Start_App.Application.Common.Interfaces;
using Start_App.Application.Production.Queries.V1.GetProductCategory;
using Microsoft.Extensions.Logging;

namespace Start_App.Application.Production.Queries.V1.GetProductSubcategory
{
    public class GetProductSubcategoryQuery : IRequest<List<ProductSubcategoryDto>>
    {
        public int Id { get; set; }
    }

    public class GetProductSubcategoryQueryHandler : IRequestHandler<GetProductSubcategoryQuery, List<ProductSubcategoryDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductSubcategoryQueryHandler> _logger;

        public GetProductSubcategoryQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetProductSubcategoryQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<List<ProductSubcategoryDto>> Handle(GetProductSubcategoryQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"ID: {request.Id}");
            return await _context.ProductSubcategories
                .Where(x => x.ProductCategoryId == request.Id)
                .ProjectTo<ProductSubcategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
