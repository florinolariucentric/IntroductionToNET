using System;
using System.Collections.Generic;
using System.Linq;
using Vanguard;

namespace Fii.Domain
{
    public class Author
    {
        private Author()
        {
            //EF
        }
        public Guid Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public ICollection<Book> Books { get; private set; }

        public Author(string firstName, string lastName)
        {
            Guard.ArgumentNotNull(firstName, nameof(firstName));
            Guard.ArgumentNotNull(lastName, nameof(lastName));
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Books = new List<Book>();
        }

        public void AttachBook(Book book)
        {
            Guard.ArgumentNotNull(book, nameof(book));
            Books.Add(book);
        }

        public Book DetachBook(Guid id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            Books.Remove(book);
            return book;
        }
    }
}
