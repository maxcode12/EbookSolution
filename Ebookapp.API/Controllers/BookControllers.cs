using Ebookapp.API.Dtos;
using Ebookapp.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ebookapp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookControllers : ControllerBase
{
    private readonly IBookServices _bookServices;
    public BookControllers(IBookServices bookServices)
    {
        _bookServices = bookServices;
    }

    [HttpGet("GetAllBooks")]
    public async Task<IActionResult> GetAllBooks()
    {
        var response = await _bookServices.GetAllBooksAsync();
        return Ok(response);
    }

    [HttpGet("GetBook{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var response = await _bookServices.GetBookByIdAsync(id);
        return Ok(response);
    }


    [HttpPost("AddBook")]
    public async Task<IActionResult> AddBook([FromBody] BookDTO book)
    {
        var response = await _bookServices.AddBookAsync(book);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBook([FromBody] BookDTO book)
    {
        var response = await _bookServices.UpdateBookAsync(book);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await _bookServices.DeleteBookAsync(id);
        return Ok();
    }

}
