using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.Application.TokenApplication.GetToken;

public class GetTokenHandler : IRequestHandler<GetTokenRequest, GetTokenResponse>
{
    private readonly string secret = "cfyupghjlsjyunynzjlxylyjaqfvdanfnjfrpnchywdqlekqbayawrfxtvfilddxunzqtrckygxagzkmhujvojmksjaapjlvuxqdlhxlxsldjocaagdocuupsuafgqhnenagyuxrwxywcy";
    
    public async Task<GetTokenResponse> Handle(GetTokenRequest request, CancellationToken cancellationToken)
    {
        var token = GenerateToken();
        return new GetTokenResponse(HttpStatusCode.OK, new GetTokenResponseBody(token));
    }

    private string GenerateToken()
    {
        var claims = new[]
        {
            new Claim("user", "test")
        };

        var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            "BookStoreApi", 
            "BookStoreUsers", 
            claims, 
            null, 
            DateTime.Now.AddMinutes(5), 
            credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}