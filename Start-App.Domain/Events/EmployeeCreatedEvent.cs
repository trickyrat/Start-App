/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using Start_App.Domain.Common;
using Start_App.Domain.Entities;

namespace Start_App.Domain.Events
{
    public class EmployeeCreatedEvent : DomainEvent
    {
        public EmployeeCreatedEvent(Employee employee)
        {
            Employee = employee;
        }
        public Employee Employee { get; set; }
    }
}
