using System.Net;
using MediatR.Pipeline;
using MongoDB.Bson;

namespace BookStore.Application.BookApplication.UpdateBook;

public class UpdateBookSerializationExceptionHandler : IRequestExceptionHandler<UpdateBookRequest, UpdateBookResponse, BsonSerializationException>
{
    public Task Handle(UpdateBookRequest request, BsonSerializationException exception, RequestExceptionHandlerState<UpdateBookResponse> state, CancellationToken cancellationToken)
    {
        state.SetHandled(new UpdateBookResponse(HttpStatusCode.BadRequest));
        return Task.CompletedTask;
    }
}