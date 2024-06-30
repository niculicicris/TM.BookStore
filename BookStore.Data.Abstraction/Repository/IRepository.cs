using BookStore.Domain;

namespace BookStore.Data.Abstraction.Repository;

public interface IRepository<T>
{
    Task<Book?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<string> InsertAsync(T item, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(T item, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(string id, CancellationToken cancellationToken);
}