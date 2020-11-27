/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System;
using System.Collections.Generic;
using AutoMapper;
using Start_App.Application.Common.Mappings;
using Start_App.Domain.Entities.Books;
using Start_App.Domain.Enums;

namespace Start_App.Application.Books.Queries
{
    public class BookDto : IMapFrom<Book>
    {
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDto>();
        }
    }
}
