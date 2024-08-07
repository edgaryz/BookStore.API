using BookStore.API.Models;
using System.Data.SqlClient;
using System.Data;

namespace BookStore.API.Contracts
{
    public interface IBookStoreRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void InsertBook(Book book);

        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}
