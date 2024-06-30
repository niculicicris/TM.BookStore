using System.Net;

namespace BookStore.Data.Abstraction.Response;

public abstract class ApiResponse
{
    public abstract int StatusCode { get; }
}