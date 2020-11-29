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
using Start_App.Application.Common.Exceptions;
using Start_App.Application.Common.Interfaces;
using Start_App.Domain.Entities.Books;

namespace Start_App.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest
    {
        /// <summary>
        /// Book Id
        /// </summary>
        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateBookCommandHandler> _logger;

        public UpdateBookCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<UpdateBookCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Books.FindAsync(request.Id);
            if(entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }
            entity.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
