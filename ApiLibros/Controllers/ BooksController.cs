using MiApiSQLite.Data;
using MiApiSQLite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MiApiSQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookContext _context;

        public BooksController(BookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        [HttpGet("isbn/{ISBN}")]
        public async Task<ActionResult<Book>> GetBooks(string ISBN)
        {
            var books = await _context.Books.FindAsync(ISBN);

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }

        [HttpGet("title/{BookTitle}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookByTitle(string BookTitle)
        {
            var books = await (
                from b in _context.Books
                where b.BookTitle != null && b.BookTitle.Contains(BookTitle)
                select b
            ).ToListAsync();

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }

        [HttpGet("Author/{BookAuthor}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookByAuthor(string BookAuthor)
        {
            var books = await (
                from b in _context.Books
                where b.BookAuthor != null && b.BookAuthor.Contains(BookAuthor)
                select b
            ).ToListAsync();

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }

        [HttpGet("year/{YearOfPublication}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookByYear(int YearOfPublication)
        {
            var books = await (
                from b in _context.Books
                where b.YearOfPublication == YearOfPublication
                select b
            ).ToListAsync();

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }

        [HttpGet("publisher/{Publisher}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookByPublisher(string Publisher)
        {
            var books = await (
                from b in _context.Books
                where b.Publisher != null && b.Publisher.Contains(Publisher)
                select b
            ).ToListAsync();

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }
        
    }
}
