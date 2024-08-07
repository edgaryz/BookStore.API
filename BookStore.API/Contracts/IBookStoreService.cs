using BookStore.API.Models;

namespace BookStore.API.Contracts
{
    public interface IBookStoreService
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void InsertBook(Book book);

        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}
