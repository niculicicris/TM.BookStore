namespace BookStore.Application.BookApplication.InsertBook;

public class InsertBookResponseBody
{
    public InsertBookResponseBody(string id)
    {
        Id = id;
    }
    
    public string Id { get; set; }
}