namespace BookStore.Application.TokenApplication.GetToken;

public class GetTokenResponseBody
{
    public GetTokenResponseBody(string token)
    {
        Token = token;
    }

    public string Token { get; set; }
}