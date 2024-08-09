using Ebookapp.API.Context;
using Ebookapp.API.Dtos;
using Ebookapp.API.Dtos.Response;
using Ebookapp.API.Interfaces;
using Ebookapp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ebookapp.API.Services;

public class BookService : IBookServices
{
    private readonly EBookContextDB _context;
    public BookService(
        EBookContextDB context)
    {
        _context = context;

    }
    public async Task<Response> AddBookAsync(BookDTO book)
    {
        if (book == null)
        {
            Response response = new Response
            {
                ISuccess = false,
                Message = "Book is Empty"
            };
        }

        var bookEntity = new Book
        {
            Title = book.Title,
            Description = book.Description,
            Price = book.Price,
            CoverImageUrl = book.CoverImageUrl,
        };


        //check if author exist if not add author
        var author = await _context.Authors
            .FirstOrDefaultAsync(a => a.Name == book.AuthorName);
        if (author == null)
        {
            author = new Author
            {

                Name = book.AuthorName,
                Bio = book.AuthorBio,
                ProfileImageUrl = book.AuthorProfileImageUrl
            };
            await _context.AddAsync(author);
        }
        //Set author relationship to book
        bookEntity.Author = author;

        await _context.AddAsync(bookEntity);
        await _context.SaveChangesAsync();

        return new Response
        {
            ISuccess = true,
            Message = "Book Added Successfully"
        };

    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return;
        }
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

    }

    public async Task<IEnumerable<Response>> GetAllBooksAsync()
    {
        var books = await _context.Books.Include(a => a.Author).ToListAsync();

        if (books == null)
        {
            return null;
        }
        return books.Select(book => new Response
        {
            ISuccess = true,
            Message = "Books Retrieved Successfully",
            Data = new BookDTO
            {
                BookID = book.BookID,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                CoverImageUrl = book.CoverImageUrl,
                AuthorName = book.Author.Name,
                AuthorBio = book.Author.Bio,
                AuthorProfileImageUrl = book.Author.ProfileImageUrl,
            }
        });
    }

    public async Task<Response> GetBookByIdAsync(int id)
    {

        var book = await _context.Books.Include(a => a.Author)
            .FirstOrDefaultAsync(k => k.BookID == id);

        if (book == null)
        {
            return null;
        }
        return new Response
        {
            ISuccess = true,
            Message = "Book Retrieved Successfully",
            Data = new BookDTO
            {
                BookID = book.BookID,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                CoverImageUrl = book.CoverImageUrl,
                AuthorName = book.Author.Name,
                AuthorBio = book.Author.Bio,
                AuthorProfileImageUrl = book.Author.ProfileImageUrl,
            }
        };
    }

    public async Task<Response> GetBooksByAuthorAsync(string author)
    {

        //var repo = _unitOfWork.GetGenericRepository<Book>();
        //var books = await repo.FirstOrDefaultAsync(k => k.Author.Name == author);

        var books = await _context.Books.Include(a => a.Author)
            .FirstOrDefaultAsync(k => k.Author.Name == author);
        var bookList = (books is null) ? "Author Is Not Found" : "";

        return new Response
        {
            ISuccess = true,
            Message = bookList,
            Data = new BookDTO
            {
                BookID = books.BookID,
                Title = books.Title,
                Description = books.Description,
                Price = books.Price,
                CoverImageUrl = books.CoverImageUrl,
                AuthorName = books.Author.Name,
                AuthorBio = books.Author.Bio,
                AuthorProfileImageUrl = books.Author.ProfileImageUrl,
            }
        };

    }



    public async Task<Response> UpdateBookAsync(BookDTO book)
    {


        var bookexist = _context.Books.FirstOrDefaultAsync(x => x.BookID == book.BookID);
        var authorexist = _context.Authors.FirstOrDefaultAsync(x => x.AuthorID == book.AuthorId);


        if (bookexist == null)
        {
            return new Response
            {
                ISuccess = false,
                Message = "Book not found"
            };
        }
        var bookEntity = new Book
        {
            Title = book.Title,
            Description = book.Description,
            Price = book.Price,
            CoverImageUrl = book.CoverImageUrl,

        };

        //check if author exist if not add author
        var author = await _context.Authors
            .FirstOrDefaultAsync(a => a.Name == book.AuthorName);
        if (author == null)
        {
            author = new Author
            {

                Name = book.AuthorName,
                Bio = book.AuthorBio,
                ProfileImageUrl = book.AuthorProfileImageUrl
            };
            await _context.AddAsync(author);
        }
        //Set author relationship to book
        bookEntity.Author = author;

        await _context.AddAsync(bookEntity);
        await _context.SaveChangesAsync();


        return new Response
        {
            ISuccess = true,
            Message = "Book Updated Successfully"
        };
    }
}
