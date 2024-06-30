using System.Net;
using MediatR.Pipeline;

namespace BookStore.Application.BookApplication.GetBookById;

public class GetBookFormatExceptionHandler : IRequestExceptionHandler<GetBookByIdRequest, GetBookByIdResponse, FormatException>
{
    public Task Handle(GetBookByIdRequest request, FormatException exception, RequestExceptionHandlerState<GetBookByIdResponse> state, CancellationToken cancellationToken)
    {
        state.SetHandled(new GetBookByIdResponse(HttpStatusCode.BadRequest, null));
        return Task.CompletedTask;
    }
}