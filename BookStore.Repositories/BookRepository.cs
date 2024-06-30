using BookStore.Data.Abstraction;
using BookStore.Data.Abstraction.Repository;
using BookStore.Domain;
using MongoDB.Driver;

namespace BookStore.Repositories;

public class BookRepository : IBookRepository
{
    private readonly IMongoCollection<Book> books;

    public BookRepository(IDatabase database)
    {
        books = database.GetCollection<IMongoCollection<Book>, Book>("Books");
    }

    public async Task<Book?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<Book>.Filter.Eq(book => book.Id, id);
        var book = await books.Find(filter).FirstOrDefaultAsync(cancellationToken);

        return book;
    }
    
    public async Task<List<Book>> GetAllAsync(CancellationToken cancellationToken)
    {
        var filter = Builders<Book>.Filter.Empty;
        var booksList = await books.Find(filter).ToListAsync(cancellationToken);

        return booksList;
    }
    
    public async Task<string> InsertAsync(Book item, CancellationToken cancellationToken)
    {
        await books.InsertOneAsync(item, new InsertOneOptions(), cancellationToken);
        return item.Id;
    }

    public async Task<bool> UpdateAsync(Book item, CancellationToken cancellationToken)
    {
        var filter = Builders<Book>.Filter.Eq(book => book.Id, item.Id);
        var result = await books.ReplaceOneAsync(filter, item, new ReplaceOptions(), cancellationToken);

        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<Book>.Filter.Eq(book => book.Id, id);
        var result = await books.DeleteOneAsync(filter, cancellationToken);

        return result.IsAcknowledged && result.DeletedCount > 0;
    }
}