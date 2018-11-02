using Fii.Domain;
using Fii.Persistence;

namespace Fii.Test
{
    static class Program
    {
        static void Main(string[] args)
        {
            IUnitOfWork unitOfWork = new UnitOfWork();


            Author author = new Author("Florin", "Olariu");

            unitOfWork.CreateAuthor(author);

            Book firstBook = new Book("First Book", author);

            unitOfWork.CreateBook(author.Id, firstBook);

            Book secondBook = new Book("Second Book", author);

            unitOfWork.CreateBook(author.Id, secondBook);


            // unitOfWork.DeleteAuthor(new Guid("30D8C115-A4B4-4F71-BFBD-FF5683AE86C2"));

            // unitOfWork.DeleteBook(new Guid("F1FFB39E-847F-4402-B1C9-29D35706E182"),
            // new Guid("1E304812-D8B4-4373-8B07-74409D15E38B"));
        }
    }
}
