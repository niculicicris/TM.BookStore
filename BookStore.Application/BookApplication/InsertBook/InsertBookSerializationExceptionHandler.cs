using System.Net;
using MediatR.Pipeline;
using MongoDB.Bson;

namespace BookStore.Application.BookApplication.InsertBook;

public class InsertBookSerializationExceptionHandler : IRequestExceptionHandler<InsertBookRequest, InsertBookResponse, BsonSerializationException>
{
    public Task Handle(InsertBookRequest request, BsonSerializationException exception, RequestExceptionHandlerState<InsertBookResponse> state, CancellationToken cancellationToken)
    {
        state.SetHandled(new InsertBookResponse(HttpStatusCode.BadRequest, null));
        return Task.CompletedTask;
    }
}