using System.Net;
using BookStore.Application.BookApplication.GetAllBooks;
using BookStore.Data.Abstraction;
using BookStore.Data.Abstraction.Repository;
using MediatR;

namespace BookStore.Application.GetAllBooks;

public class GetAllBooksHandler : IRequestHandler<GetAllBooksRequest, GetAllBooksResponse>
{
    private readonly IBookRepository bookRepository;

    public GetAllBooksHandler(IBookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    public async Task<GetAllBooksResponse> Handle(GetAllBooksRequest request, CancellationToken cancellationToken)
    {
        var books = await bookRepository.GetAllAsync(cancellationToken);
        return new GetAllBooksResponse(HttpStatusCode.OK, books);
    }
}