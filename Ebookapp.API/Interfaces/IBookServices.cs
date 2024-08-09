using Ebookapp.API.Dtos;
using Ebookapp.API.Dtos.Response;

namespace Ebookapp.API.Interfaces;

public interface IBookServices
{
    Task<IEnumerable<Response>> GetAllBooksAsync();
    Task<Response> GetBookByIdAsync(int id);
    Task<Response> AddBookAsync(BookDTO book);
    Task<Response> UpdateBookAsync(BookDTO book);
    Task DeleteBookAsync(int id);
    Task<Response> GetBooksByAuthorAsync(string author);
}
