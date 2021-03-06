﻿/*
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

namespace Start_App.Application.Production.Queries.V1.GetProduct
{
    public class GetProductsWithPaginationQuery : IRequest<PagedList<ProductDto>>
    {
        public int SubcategoryId { get; set; }

        public string FilterQuery { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsWithPaginationQuery, PagedList<ProductDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PagedList<ProductDto>> Handle(GetProductsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Products.AsQueryable();
            if (request.SubcategoryId > 0)
            {
                query = query.Where(x => x.ProductSubcategoryId == request.SubcategoryId);
            }
            if (!string.IsNullOrEmpty(request.FilterQuery))
            {
                query = query.Where(x => x.Name.Contains(request.FilterQuery));
            }
            return await query.ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .PagedListAsync(request.PageIndex, request.PageSize);
        }
    }
}
