using Ebookapp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ebookapp.API.DataSeed;

public class BookSeed : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasData(

            new Book
            {
                BookID = 1,
                Title = "The Great Gatsby",
                AuthorID = 1,
                Description = "The Great Gatsby is a 1925 novel by American writer F. Scott Fitzgerald. Set in the Jazz Age on Long Island, near New York City, the novel depicts first-person narrator Nick Carraway's interactions with mysterious millionaire Jay Gatsby and Gatsby's obsession to reunite with his former lover, Daisy Buchanan.",
                Price = Convert.ToDecimal(9.99),
                CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51ZJ2q4SjyL._SX331_BO1,204,203,200_.jpg"
            },
            new Book
            {
                BookID = 2,
                Title = "To Kill a Mockingbird",
                AuthorID = 2,
                Description = "To Kill a Mockingbird is a novel by the American author Harper Lee. It was published in 1960 and was instantly successful. In the United States, it is widely read in high schools and middle schools.",
                Price = Convert.ToDecimal(7.99),
                CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51ZJ2q4SjyL._SX331_BO1,204,203,200_.jpg"
            },
            new Book
            {
                BookID = 3,
                Title = "1984",
                AuthorID = 3,
                Description = "1984 is a dystopian social science fiction novel by English novelist George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime.",
                Price = Convert.ToDecimal(11.99),
                CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51ZJ2q4SjyL._SX331_BO1,204,203,200_.jpg"
            },
            new Book
            {
                BookID = 4,
                Title = "The Catcher in the Rye",
                AuthorID = 4,
                Description = "The Catcher in the Rye is a novel by J. D. Salinger, partially published in serial form in 1945–1946 and as a novel in 1951. It was originally intended for adults but is often read by adolescents for its themes)",
                Price = Convert.ToDecimal(6.99),
                CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51ZJ2q4SjyL._SX331_BO1,204,203,200_.jpg"
            });
    }

}
