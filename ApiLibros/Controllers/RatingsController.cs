using MiApiSQLite.Data;
using MiApiSQLite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MiApiSQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly RatingContext _context;
        private readonly BookContext _bookContext;

        public RatingsController(RatingContext context, BookContext bookContext)
        {
            _context = context;
            _bookContext = bookContext;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ratings>>> GetRatings()
        {
            return await _context.Ratings.ToListAsync();
        }

        [HttpGet("isbn/{ISBN}")]
        public async Task<ActionResult<Ratings>> GetRatingByIsbn(string ISBN)
        {
            var ratings = await _context.Ratings.FindAsync(ISBN);

            if (ratings == null)
            {
                return NotFound();
            }

            return ratings;
        }

        [HttpPost]
        public async Task<ActionResult<Ratings>> AddRating(int UserID, string ISBN, int BookRating)
        {
            bool isbnExists = await (
                from b in _bookContext.Books
                where b.ISBN == ISBN
                select b
            ).AnyAsync();

            if (!isbnExists)
            {
                return BadRequest("El ISBN no existe en la base de datos de libros.");
            }

            var rating = new Ratings
            {
                UserID = UserID,
                ISBN = ISBN,
                BookRating = BookRating,
            };
            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRatingByIsbn), new { isbn = rating.ISBN }, rating);
        }

        [HttpGet("user_id/{UserID}")]
        public async Task<ActionResult<List<Ratings>>> GetRatingByUser(int UserID)
        {
            var ratings = await (
                from b in _context.Ratings
                where b.UserID == UserID
                select b
            ).ToListAsync();

            if (ratings == null || !ratings.Any())
            {
                return NotFound();
            }

            return ratings;
        }

        [HttpGet("book_rating/{BookRating}")]
        public async Task<ActionResult<List<Ratings>>> GetRatingByBook(int BookRating)
        {
            var ratings = await (
                from b in _context.Ratings
                where b.BookRating == BookRating
                select b
            ).ToListAsync();

            if (ratings == null || !ratings.Any())
            {
                return NotFound();
            }

            return ratings;
        }

        private async Task<bool> RatingExists(string isbn)
        {
            return await _context.Ratings.AnyAsync(e => e.ISBN == isbn);
        }
    }
}
