using BookStore.Domain.dto;
using MediatR;

namespace BookStore.Application.BookApplication.UpdateBook;

public class UpdateBookRequest : IRequest<UpdateBookResponse>
{
    public UpdateBookRequest(string id, BookDto book)
    {
        Id = id;
        Book = book;
    }

    public string Id { get; }

    public BookDto Book { get; }
}