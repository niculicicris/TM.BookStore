using System.Net;
using BookStore.Data.Abstraction;
using BookStore.Data.Abstraction.Repository;
using BookStore.Domain;
using FluentValidation;
using MediatR;

namespace BookStore.Application.BookApplication.InsertBook;

public class InsertBookHandler : IRequestHandler<InsertBookRequest, InsertBookResponse>
{
    private readonly IBookRepository bookRepository;
    private readonly IValidator<InsertBookRequest> validator;

    public InsertBookHandler(IBookRepository bookRepository, IValidator<InsertBookRequest> validator)
    {
        this.bookRepository = bookRepository;
        this.validator = validator;
    }

    public async Task<InsertBookResponse> Handle(InsertBookRequest request, CancellationToken cancellationToken)
    {
        var validation = await validator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid) return new InsertBookResponse(HttpStatusCode.BadRequest, null);
        
        var book = new Book(request.Book);
        await bookRepository.InsertAsync(book, cancellationToken);

        return new InsertBookResponse(HttpStatusCode.Created, new InsertBookResponseBody(book.Id));
    }
}