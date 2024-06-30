using System.Net;
using MediatR.Pipeline;

namespace BookStore.Application.BookApplication.UpdateBook;

public class UpdateBookFormatExceptionHandler : IRequestExceptionHandler<UpdateBookRequest, UpdateBookResponse, FormatException>
{
    public Task Handle(UpdateBookRequest request, FormatException exception, RequestExceptionHandlerState<UpdateBookResponse> state, CancellationToken cancellationToken)
    {
        state.SetHandled(new UpdateBookResponse(HttpStatusCode.BadRequest));
        return Task.CompletedTask;
    }
}