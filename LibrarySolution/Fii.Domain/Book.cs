using System;
using Vanguard;

namespace Fii.Domain
{
    public class Book
    {
        private Book()
        {
            // EF
        }
        public Book(string title, Author author)
        {
            Guard.ArgumentNotNullOrEmpty(title, nameof(title));
            Guard.ArgumentNotNull(author, nameof(author));
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
        }
        public Guid Id { get; private set; }

        public string Title { get; private set; }

        public Author Author { get; private set; }
    }
}