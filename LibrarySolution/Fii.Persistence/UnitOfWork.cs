using System;
using System.Linq;
using Fii.Domain;
using Microsoft.EntityFrameworkCore;
using Vanguard;

namespace Fii.Persistence
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;

        public UnitOfWork()
        {
            _context = new LibraryContext();
        }

        public void CreateAuthor(Author author)
        {
            Guard.ArgumentNotNull(author, nameof(author));
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void DeleteAuthor(Guid id)
        {
            var author = _context.Authors.Include(a => a.Books).FirstOrDefault(a => a.Id == id);
            if (author!=null)
            {
                _context.Remove(author);
                foreach (var authorBook in author.Books)
                {
                    MarkAsDeleted(authorBook);
                }
                _context.SaveChanges();
            }
        }

        public void CreateBook(Guid authorId, Book book)
        {
            var author = _context.Authors.FirstOrDefault(a => a.Id == authorId);
            if (author != null)
            {
                author.AttachBook(book);
                _context.SaveChanges();
            }
        }

        public void DeleteBook(Guid authorId, Guid bookId)
        {
            var author = _context.Authors.Include(a => a.Books).FirstOrDefault(a => a.Id == authorId);
            if (author!=null)
            {
                MarkAsDeleted(author.DetachBook(bookId));
                _context.SaveChanges();
            }
        }

        private void MarkAsDeleted(Book authorBook)
        {
            _context.Entry(authorBook).State = EntityState.Deleted;
        }
    }
}
