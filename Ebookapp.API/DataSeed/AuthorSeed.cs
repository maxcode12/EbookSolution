using Ebookapp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ebookapp.API.DataSeed
{
    public class AuthorSeed : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(
                new Author
                {
                    AuthorID = 1,
                    Name = "F. Scott Fitzgerald",
                    Bio = "Francis Scott Key Fitzgerald (September 24, 1896 – December 21, 1940) was an American novelist, essayist, screenwriter, and short-story writer. He was best known for his novels depicting the flamboyance and excess of the Jazz Age—a term he popularized. During his lifetime, he published four novels, four collections of short stories, and 164 short stories. Although he temporarily achieved popular success and fortune in the 1920s, Fitzgerald only received wide critical and popular acclaim after his death.",
                    ProfileImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/0c/F_Scott_Fitzgerald_1921.jpg"
                },
                new Author
                {
                    AuthorID = 2,
                    Name = "Harper Lee",
                    Bio = "Nelle Harper Lee (April 28, 1926 – February 19, 2016) was an American novelist best known for her 1960 novel To Kill a Mockingbird. It won the 1961 Pulitzer Prize and has become a classic of modern American literature. Lee published only two books, yet she was awarded the Presidential Medal of Freedom in 2007 for her contribution to literature. She also received numerous honorary degrees, though she declined to speak on those occasions. She assisted her close friend Truman Capote in his research for the book In Cold Blood (1966). Capote was the basis for the character Dill in To Kill a Mockingbird.",
                    ProfileImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/4f/Harper_Lee_1961.jpg"
                },
                new Author
                {
                    AuthorID = 3,
                    Name = "George Orwell",
                    Bio = "Eric Arthur Blair (25 June 1903 – 21 January 1950), known by his pen name George Orwell, was an English novelist, essayist, journalist and critic. His work is characterised by lucid prose, biting social criticism, opposition to totalitarianism, and outspoken support of democratic socialism.",
                    ProfileImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/0c/George_Orwell_press_photo.jpg"
                },
                new Author
                {
                    AuthorID = 4,
                    Name = "J. D. Salinger",
                    Bio = "Jerome David Salinger (January 1, 1919 – January 27, 2010) was an American writer best known for his 1951 novel The Catcher in the Rye. Before its publication, Salinger published several short stories in Story magazine and served in World War II. In 1948, his critically acclaimed story \"A Perfect Day for Bananafish\" appeared in The New Yorker, which published much of his later work.",
                    ProfileImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/0c/J._D._Salinger.jpg"
                });
        }
    }
}
