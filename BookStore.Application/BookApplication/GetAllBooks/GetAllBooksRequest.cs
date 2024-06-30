using MediatR;

namespace BookStore.Application.BookApplication.GetAllBooks;

public class GetAllBooksRequest : IRequest<GetAllBooksResponse> { }