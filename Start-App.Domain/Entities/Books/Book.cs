﻿/*
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
        public Guid Id { get; set; }
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public decimal Price { get; set; }

        public ICollection<Author> Authors { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
