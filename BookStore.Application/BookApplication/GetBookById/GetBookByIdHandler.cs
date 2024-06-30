using System.Net;
using BookStore.Data.Abstraction;
using BookStore.Data.Abstraction.Repository;
using MediatR;

namespace BookStore.Application.BookApplication.GetBookById;

public class GetBookByIdHandler : IRequestHandler<GetBookByIdRequest, GetBookByIdResponse>
{
    private readonly IBookRepository bookRepository;

    public GetBookByIdHandler(IBookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }
    
    public async Task<GetBookByIdResponse> Handle(GetBookByIdRequest request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetByIdAsync(request.Id, cancellationToken);
        if (book == null) return new GetBookByIdResponse(HttpStatusCode.NotFound, null);
        
        return new GetBookByIdResponse(HttpStatusCode.OK, book);
    }
}