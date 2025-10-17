using System.ComponentModel.DataAnnotations;

namespace MiApiSQLite.Models
{
    // Models/libros.cs
    public class Book
    {
        [Key]
        public string? ISBN { get; set; }
        public string? BookTitle { get; set; }
        public string? BookAuthor { get; set; }
        public int? YearOfPublication { get; set; }
        public string? Publisher { get; set; }
        public string? ImageUrlS { get; set; }
        public string? ImageUrlM { get; set; }
        public string? ImageUrlL { get; set; }
    }
}
