using System.Net;
using BookStore.Data.Abstraction.Response;

namespace BookStore.Application.BookApplication.DeleteBook;

public class DeleteBookResponse : ApiResponse
{
    public DeleteBookResponse(HttpStatusCode statusCode)
    {
        StatusCode = (int) statusCode;
    }
    
    public override int StatusCode { get; }
}