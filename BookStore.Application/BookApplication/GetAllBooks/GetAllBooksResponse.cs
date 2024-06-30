using System.Net;
using BookStore.Data.Abstraction.Response;
using BookStore.Domain;

namespace BookStore.Application.BookApplication.GetAllBooks;

public class GetAllBooksResponse : BodyApiResponse<List<Book>>
{
    public GetAllBooksResponse(HttpStatusCode statusCode, List<Book> value)
    {
        StatusCode = (int) statusCode;
        Value = value;
    }

    public override int StatusCode { get; }
    
    public override List<Book> Value { get; }
}