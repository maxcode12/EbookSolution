namespace Ebookapp.API.Models;

public class Author
{
    public int AuthorID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string ProfileImageUrl { get; set; } = string.Empty;

    public ICollection<Book> Books { get; set; }
}
