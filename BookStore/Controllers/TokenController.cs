using BookStore.Application.TokenApplication.GetToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

[ApiController]
[Route("token")]
public class TokenController : ControllerBase
{
    private readonly IMediator mediator;

    public TokenController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetToken(CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetTokenRequest(), cancellationToken);
        return StatusCode(response.StatusCode, response.Value);
    }
}