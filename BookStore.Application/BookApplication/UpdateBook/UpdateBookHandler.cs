using System.Net;
using BookStore.Data.Abstraction;
using BookStore.Data.Abstraction.Repository;
using BookStore.Domain;
using FluentValidation;
using MediatR;

namespace BookStore.Application.BookApplication.UpdateBook;

public class UpdateBookHandler : IRequestHandler<UpdateBookRequest, UpdateBookResponse>
{
    private readonly IBookRepository bookRepository;
    private readonly IValidator<UpdateBookRequest> validator;

    public UpdateBookHandler(IBookRepository bookRepository, IValidator<UpdateBookRequest> validator)
    {
        this.bookRepository = bookRepository;
        this.validator = validator;
    }

    public async Task<UpdateBookResponse> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
    {
        var validation = await validator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid) return new UpdateBookResponse(HttpStatusCode.BadRequest);

        var isUpdated = await bookRepository.UpdateAsync(new Book(request.Id, request.Book), cancellationToken);
        if (!isUpdated) return new UpdateBookResponse(HttpStatusCode.NotFound);

        return new UpdateBookResponse(HttpStatusCode.OK);
    }
}