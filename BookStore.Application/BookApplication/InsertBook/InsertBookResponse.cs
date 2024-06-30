using System.Net;
using BookStore.Data.Abstraction.Response;

namespace BookStore.Application.BookApplication.InsertBook;

public class InsertBookResponse : BodyApiResponse<InsertBookResponseBody?>
{
    public InsertBookResponse(HttpStatusCode statusCode, InsertBookResponseBody? responseBody)
    {
        StatusCode = (int) statusCode;
        Value = responseBody;
    }
    
    public override int StatusCode { get; }
    
    public override InsertBookResponseBody? Value { get; }
}