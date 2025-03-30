using Microsoft.AspNetCore.Mvc;
using BookApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", Author = "Author 1", ISBN = "1234567890", PublicationDate = new DateTime(2021, 1, 1) },
            new Book { Id = 2, Title = "Book 2", Author = "Author 2", ISBN = "0987654321", PublicationDate = new DateTime(2020, 5, 12) },
        };

        // GET: api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(_books);
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public ActionResult<Book> AddBook([FromBody] Book book)
        {
            book.Id = _books.Max(b => b.Id) + 1;  // Auto-increment ID
            _books.Add(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.ISBN = book.ISBN;
            existingBook.PublicationDate = book.PublicationDate;

            return NoContent();  // Return 204 No Content when update is successful
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            _books.Remove(book);
            return NoContent();  // Return 204 No Content when deletion is successful
        }
    }
}
