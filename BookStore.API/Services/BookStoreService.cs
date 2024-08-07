using BookStore.API.Contracts;
using BookStore.API.Models;

namespace BookStore.API.Services
{
    public class BookStoreService : IBookStoreService
    {
        public readonly IBookStoreRepository _bookStoreRepository;
        public BookStoreService(IBookStoreRepository bookStoreRepository)
        {
            _bookStoreRepository = bookStoreRepository;
        }

        public List<Book> GetAllBooks()
        {
            return _bookStoreRepository.GetAllBooks();
        }

        public Book GetBookById(int id)
        {
            return _bookStoreRepository.GetBookById(id);
        }

        public void InsertBook(Book book)
        {
            _bookStoreRepository.InsertBook(book);
        }

        public void UpdateBook(Book book)
        {
            _bookStoreRepository.UpdateBook(book);
        }

        public void DeleteBook(int id)
        {
            _bookStoreRepository.DeleteBook(id);
        }
    }
}
