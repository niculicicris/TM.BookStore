using MediatR;

namespace BookStore.Application.BookApplication.DeleteBook;

public class DeleteBookRequest : IRequest<DeleteBookResponse>
{
    public DeleteBookRequest(string id)
    {
        Id = id;
    }
    
    public string Id { get; }
}