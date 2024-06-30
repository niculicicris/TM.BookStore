namespace BookStore.Data.Abstraction.Response;

public abstract class BodyApiResponse<T> : ApiResponse
{
    public abstract T Value { get; }
}