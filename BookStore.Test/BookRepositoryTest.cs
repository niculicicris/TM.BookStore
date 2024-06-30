using BookStore.Data.Abstraction;
using BookStore.Data.Abstraction.Repository;
using BookStore.Data.MongoDB;
using BookStore.Domain;
using BookStore.Repositories;
using Xunit.Abstractions;

namespace BookStore.Test;

public class BookRepositoryTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private IDatabaseConfiguration databaseConfiguration;
    private IDatabase database;
    private IBookRepository bookRepository;
    
    public BookRepositoryTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        databaseConfiguration = new DatabaseConfiguration
        {
            ConnectionString = "mongodb+srv://niculicicris:P2Yf2CEM1FImIZI1@cluster0.4aamwuf.mongodb.net/",
            DatabaseName = "BookStore"
        };

        database = new Database(databaseConfiguration);
        bookRepository = new BookRepository(database);
    }

    [Theory]
    [InlineData("64923fb060592343846ae20a")]
    [InlineData("64923fb060592343846ae206")]
    [InlineData("64923fb060592343846ae253")]
    public async Task ShouldGetBook(string id)
    {
        var foundBook = await bookRepository.GetByIdAsync(id, CancellationToken.None);
        Assert.NotNull(foundBook);
;   }

    [Fact]
    public async Task ShouldGetAllBooks()
    {
        var books = await bookRepository.GetAllAsync(CancellationToken.None);
        
        Assert.NotNull(books);
        Assert.NotEmpty(books);
    }
    
    [Fact]
    public async Task ShouldInsertAndDeleteBook()
    {
        var testBook = CreateTestBook(); 

        await bookRepository.InsertAsync(testBook, CancellationToken.None);
        var insertedBook = await bookRepository.GetByIdAsync(testBook.Id, CancellationToken.None);
        var isDeleted = await bookRepository.DeleteAsync(testBook.Id, CancellationToken.None);
        var deletedBook = await bookRepository.GetByIdAsync(testBook.Id, CancellationToken.None);

        Assert.NotNull(insertedBook);
        Assert.True(isDeleted);
        Assert.Null(deletedBook);
    }

    [Fact]
    public async Task ShouldUpdateAndDelete()
    {
        var testBook = CreateTestBook(); 

        await bookRepository.InsertAsync(testBook, CancellationToken.None);
        var foundBook = await bookRepository.GetByIdAsync(testBook.Id, CancellationToken.None);
        
        Assert.NotNull(foundBook);
        
        testBook.Title = "book_unit_testing_updated";
        var isUpdated = await bookRepository.UpdateAsync(testBook, CancellationToken.None);
        var updatedBook = await bookRepository.GetByIdAsync(testBook.Id, CancellationToken.None);
        
        Assert.True(isUpdated);
        Assert.NotNull(updatedBook);
        Assert.Equal("book_unit_testing_updated", updatedBook.Title);
        
        var isDeleted = await bookRepository.DeleteAsync(testBook.Id, CancellationToken.None);
        var deletedBook = await bookRepository.GetByIdAsync(testBook.Id, CancellationToken.None);
        
        Assert.True(isDeleted);
        Assert.Null(deletedBook);
    }

    private Book CreateTestBook()
    {
        return new Book
        {
            Title = "book_unit_testing",
            AuthorId = "64923fb060592343846add8e",
            PublisherId = "64923fb060592343846ae194",
            YearOfPublication = DateTime.Now,
            Genres = new List<string> { "Programming", "Testing" }
        };
    }
}