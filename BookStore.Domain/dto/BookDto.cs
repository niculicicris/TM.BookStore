namespace BookStore.Domain.dto;

public class BookDto
{
    public string Title { get; set; } = string.Empty;
    public string AuthorId { get; set; } = string.Empty;
    public string PublisherId { get; set; } = string.Empty;
    public DateTime YearOfPublication { get; set; } = DateTime.Now;
    public List<string> Genres { get; set; } = new();
}