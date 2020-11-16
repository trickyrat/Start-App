/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System;
using System.Collections.Generic;
using Start_App.Domain.Common;
using Start_App.Domain.Enums;

namespace Start_App.Domain.Entities.Books
{
    public class Book : AuditableEntity, IHasDomainEvent
    {
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
