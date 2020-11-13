/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Start_App.Application.Common.Models;
using Start_App.Domain.Events;

namespace Start_App.Application.HumanResources.EvenetHandlers.V1.CreateEmployee
{
    public class EmployeeCreatedEventHandler : INotificationHandler<DomainEventNotification<EmployeeCreatedEvent>>
    {
        private readonly ILogger<EmployeeCreatedEventHandler> _logger;

        public EmployeeCreatedEventHandler(ILogger<EmployeeCreatedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(DomainEventNotification<EmployeeCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;
            _logger.LogInformation($"Start-App Domain Event: {domainEvent.GetType().Name}");
            return Task.CompletedTask;
        }
    }
}
