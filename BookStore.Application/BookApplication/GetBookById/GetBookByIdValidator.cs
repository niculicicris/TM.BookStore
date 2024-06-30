using FluentValidation;

namespace BookStore.Application.BookApplication.GetBookById;

public class GetBookByIdValidator : AbstractValidator<GetBookByIdRequest>
{
    public GetBookByIdValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
    }
}