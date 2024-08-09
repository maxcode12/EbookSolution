namespace Ebookapp.API.Dtos;

public class BookDTO
{
    public int? BookID { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string CoverImageUrl { get; set; } = string.Empty;
    public int? AuthorId { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public string AuthorBio { get; set; } = string.Empty;
    public string AuthorProfileImageUrl { get; set; } = string.Empty;
    //public List<string> Genres { get; set; }
}
