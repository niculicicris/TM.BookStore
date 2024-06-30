using FluentValidation;

namespace BookStore.Application.BookApplication.InsertBook;

public class InsertBookValidator : AbstractValidator<InsertBookRequest>
{
    public InsertBookValidator()
    {
        RuleFor(request => request.Book).NotNull();
        RuleFor(request => request.Book.Title).NotEmpty();
        RuleFor(request => request.Book.AuthorId).NotEmpty();
        RuleFor(request => request.Book.PublisherId).NotEmpty();
        RuleFor(request => request.Book.YearOfPublication).NotNull();
        RuleFor(request => request.Book.Genres).NotEmpty();
    }
}