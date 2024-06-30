using System.Net;
using BookStore.Data.Abstraction.Response;

namespace BookStore.Application.TokenApplication.GetToken;

public class GetTokenResponse : BodyApiResponse<GetTokenResponseBody?>
{
    public GetTokenResponse(HttpStatusCode statusCode, GetTokenResponseBody? value)
    {
        StatusCode = (int) statusCode;
        Value = value;
    }

    public override int StatusCode { get; }
    
    public override GetTokenResponseBody? Value { get; }
}