/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Start_App.Application.Common.Interfaces;
using Start_App.Application.Common.Mappings;
using Start_App.Application.Common.Models;

namespace Start_App.Application.Books.Queries
{
    public class GetBooksWithPaginationQuery : IRequest<PagedList<BookDto>>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string BookType { get; set; }

        public string BookName { get; set; }

        public string Author { get; set; }
    }

    public class GetBooksWithPaginationQueryHandler : IRequestHandler<GetBooksWithPaginationQuery, PagedList<BookDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetBooksWithPaginationQueryHandler> _logger;

        public GetBooksWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetBooksWithPaginationQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PagedList<BookDto>> Handle(GetBooksWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Books.AsNoTracking();
            if(!string.IsNullOrEmpty(request.BookName))
            {
                query = query.Where(b => b.Name.Contains(request.BookName));
            }
            return await query.ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                .PagedListAsync(request.PageIndex, request.PageSize);
        }
    }
    
}
