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
using MediatR;
using Microsoft.Extensions.Logging;
using Start_App.Application.Common.Interfaces;
using Start_App.Domain.Entities.Books;

namespace Start_App.Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Guid>
    {
        public string BookName { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateBookCommandHandler> _logger;

        public CreateBookCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<CreateBookCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var entity = new Book
            {
                Id = Guid.NewGuid(),
                Name = request.BookName,
                Price = request.Price,         
            };
            _context.Books.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

    }
}
