using System.ComponentModel.DataAnnotations;

namespace Ebookapp.API.Models
{
    public class Book
    {
        public int BookID { get; set; }
        [Required]
        [StringLength(256)]
        public string Title { get; set; } = string.Empty;
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string CoverImageUrl { get; set; } = string.Empty;

        public ICollection<BookGenre> BookGenres { get; set; }
        public ICollection<Purchase> Purchases { get; set; }

    }
}
