using BookStore.Application.BookApplication.DeleteBook;
using BookStore.Application.BookApplication.GetAllBooks;
using BookStore.Application.BookApplication.GetBookById;
using BookStore.Application.BookApplication.InsertBook;
using BookStore.Application.BookApplication.UpdateBook;
using BookStore.Domain.dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

[ApiController]
[Route("book")]
public class BookController : ControllerBase
{
    private readonly IMediator mediator;

    public BookController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetBookByIdRequest(id), cancellationToken);
        return StatusCode(response.StatusCode, response.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooks(CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetAllBooksRequest(), cancellationToken);
        return StatusCode(response.StatusCode, response.Value);
    }

    [HttpPost]
    public async Task<IActionResult> InsertBook([FromBody] BookDto book, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new InsertBookRequest(book), cancellationToken);
        return StatusCode(response.StatusCode, response.Value);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(string id, [FromBody] BookDto book, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new UpdateBookRequest(id, book), cancellationToken);
        return StatusCode(response.StatusCode);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new DeleteBookRequest(id), cancellationToken);
        return StatusCode(response.StatusCode);
    }
}