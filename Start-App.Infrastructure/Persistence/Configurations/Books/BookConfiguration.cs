/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Start_App.Domain.Entities.Books;

namespace Start_App.Infrastructure.Persistence.Configurations.Books
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Ignore(e => e.DomainEvents);
            builder.HasMany(b => b.Authors)
                .WithMany(b => b.Books)
                .UsingEntity<BookAuthor>(
                    j => j
                        .HasOne(ba => ba.Author)
                        .WithMany(a => a.BookAuthors)
                        .HasForeignKey(ba => ba.AuthorId),
                    j => j
                        .HasOne(ba => ba.Book)
                        .WithMany(b => b.BookAuthors)
                        .HasForeignKey(ba => ba.BookId),
                    j =>
                    {
                        j.HasKey(ba => new { ba.AuthorId, ba.BookId });
                    });
        }
    }
}
