using BookStore.Domain.dto;

namespace BookStore.Domain;

public class Book
{
    public Book() { }
    
    public Book(BookDto bookDto)
    {
        Title = bookDto.Title;
        AuthorId = bookDto.AuthorId;
        PublisherId = bookDto.PublisherId;
        YearOfPublication = bookDto.YearOfPublication;
        Genres = bookDto.Genres;
    }
    
    public Book(string id, BookDto bookDto)
    {
        Id = id;
        Title = bookDto.Title;
        AuthorId = bookDto.AuthorId;
        PublisherId = bookDto.PublisherId;
        YearOfPublication = bookDto.YearOfPublication;
        Genres = bookDto.Genres;
    }
    
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string AuthorId { get; set; } = string.Empty;
    public string PublisherId { get; set; } = string.Empty;
    public DateTime YearOfPublication { get; set; } = DateTime.Now;
    public List<string> Genres { get; set; } = new();
}