using System;
using Fii.Domain;

namespace Fii.Persistence
{
    public interface IUnitOfWork
    {
        void CreateAuthor(Author author);
        void DeleteAuthor(Guid id);
        void CreateBook(Guid authorId, Book book);
        void DeleteBook(Guid authorId, Guid bookId);
    }
}