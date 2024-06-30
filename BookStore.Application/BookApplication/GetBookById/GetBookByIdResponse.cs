using System.Net;
using BookStore.Data.Abstraction.Response;
using BookStore.Domain;

namespace BookStore.Application.BookApplication.GetBookById;

public class GetBookByIdResponse : BodyApiResponse<Book?>
{
    public GetBookByIdResponse(HttpStatusCode statusCode, Book? value)
    {
        StatusCode = (int) statusCode;
        Value = value;
    }
    
    public override int StatusCode { get; }
    
    public override Book? Value { get; }
}