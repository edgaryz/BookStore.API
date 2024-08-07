using BookStore.API.Contracts;
using BookStore.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    public class BookStoreController : Controller
    {
        private readonly IBookStoreService _bookStoreService;
        public BookStoreController(IBookStoreService bookStoreService)
        {
            _bookStoreService = bookStoreService;
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookStoreService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("GetBookById")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookStoreService.GetBookById(id);
            return Ok(book);
        }

        [HttpPost("InsertBook")]
        public IActionResult InsertBook(Book book)
        {
            try
            {
                _bookStoreService.InsertBook(book);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee(Book book)
        {
            try
            {
                _bookStoreService.UpdateBook(book);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("DeleteBookById")]
        public IActionResult DeleteBookById(int id)
        {
            _bookStoreService.DeleteBook(id);
            return Ok();
        }
    }
}
