namespace BookStore.Data.Abstraction;

public interface IDatabase
{
    TCollection GetCollection<TCollection, TItem>(string collectionName) where TCollection : class;
}