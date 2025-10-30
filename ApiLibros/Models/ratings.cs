using System.ComponentModel.DataAnnotations;

namespace MiApiSQLite.Models

{
    // Models/Ratings.cs
    public class Ratings
    {
        [Key]
        public string? ISBN { get; set; }
        public int? UserID { get; set; }
        public int? BookRating { get; set; }
       
    }

}