/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Start_App.Application.Common.Interfaces;
using Start_App.Application.Common.Models;
using Start_App.Domain.Common;

namespace Start_App.Infrastructure.Services
{
    public class DomainEventService : IDomainEventService
    {
        private readonly ILogger<DomainEventService> _logger;
        private readonly IMediator _mediator;
        public DomainEventService(ILogger<DomainEventService> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;

        }
        public async Task Publish(DomainEvent domainEvent)
        {
            _logger.LogInformation($"Publish domain event. Event - {domainEvent.GetType().Name}");
            await _mediator.Publish(GetNotificationCorrespondingToDomainEvent(domainEvent));
        }

        private INotification GetNotificationCorrespondingToDomainEvent(DomainEvent domainEvent)
        {
            return (INotification)Activator.CreateInstance(typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent);
        }
    }
}
