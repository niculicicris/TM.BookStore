using MediatR;

namespace BookStore.Application.BookApplication.GetBookById;

public class GetBookByIdRequest : IRequest<GetBookByIdResponse>
{
    public GetBookByIdRequest(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
}