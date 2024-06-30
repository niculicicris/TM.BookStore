using FluentValidation;

namespace BookStore.Application.BookApplication.UpdateBook;

public class UpdateBookValidator : AbstractValidator<UpdateBookRequest>
{
    public UpdateBookValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
        RuleFor(request => request.Book).NotNull();
        RuleFor(request => request.Book.Title).NotEmpty();
        RuleFor(request => request.Book.AuthorId).NotEmpty();
        RuleFor(request => request.Book.PublisherId).NotEmpty();
        RuleFor(request => request.Book.YearOfPublication).NotNull();
        RuleFor(request => request.Book.Genres).NotEmpty();
    }
}