using System.Net;
using BookStore.Data.Abstraction;
using BookStore.Data.Abstraction.Repository;
using MediatR;

namespace BookStore.Application.BookApplication.DeleteBook;

public class DeleteBookHandler : IRequestHandler<DeleteBookRequest, DeleteBookResponse>
{
    private readonly IBookRepository bookRepository;

    public DeleteBookHandler(IBookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    public async Task<DeleteBookResponse> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
    {
        var isDeleted = await bookRepository.DeleteAsync(request.Id, cancellationToken);
        if (!isDeleted) return new DeleteBookResponse(HttpStatusCode.NotFound);
        
        return new DeleteBookResponse(HttpStatusCode.OK);
    }
}