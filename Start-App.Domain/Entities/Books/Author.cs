/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start_App.Domain.Entities.Books
{
    public class Author
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public ICollection<Book> Books { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
    }
}
