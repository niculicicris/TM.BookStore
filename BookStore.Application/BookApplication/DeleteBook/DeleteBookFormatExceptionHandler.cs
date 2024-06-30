using System.Net;
using MediatR.Pipeline;

namespace BookStore.Application.BookApplication.DeleteBook;

public class DeleteBookFormatExceptionHandler : IRequestExceptionHandler<DeleteBookRequest, DeleteBookResponse, FormatException>
{
    public Task Handle(DeleteBookRequest request, FormatException exception, RequestExceptionHandlerState<DeleteBookResponse> state, CancellationToken cancellationToken)
    {
        state.SetHandled(new DeleteBookResponse(HttpStatusCode.BadRequest));
        return Task.CompletedTask;
    }
}