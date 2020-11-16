/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Start_App.Application.Common.Interfaces;

namespace Start_App.Application.Production.Queries.V1.GetProductCategory
{
    public class GetProductCategoryQuery : IRequest<List<ProductCategoryDto>>
    {

    }

    public class GetProductCategoryQueryHandler : IRequestHandler<GetProductCategoryQuery, List<ProductCategoryDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductCategoryQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProductCategoryDto>> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _context.ProductCategories
                .ProjectTo<ProductCategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
