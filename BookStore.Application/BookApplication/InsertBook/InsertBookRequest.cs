using BookStore.Domain.dto;
using MediatR;

namespace BookStore.Application.BookApplication.InsertBook;

public class InsertBookRequest : IRequest<InsertBookResponse>
{
    public InsertBookRequest(BookDto book)
    {
        Book = book;
    }

    public BookDto Book { get; }
}