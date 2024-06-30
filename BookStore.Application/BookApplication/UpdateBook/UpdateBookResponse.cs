using System.Net;
using BookStore.Data.Abstraction.Response;

namespace BookStore.Application.BookApplication.UpdateBook;

public class UpdateBookResponse : ApiResponse
{
    public UpdateBookResponse(HttpStatusCode statusCode)
    {
        StatusCode = (int) statusCode;
    }

    public override int StatusCode { get; }
}