using BookStore.Data.Abstraction;

namespace BookStore.Data.MongoDB;

public class DatabaseConfiguration : IDatabaseConfiguration
{
    public string ConnectionString { get; set; }
    
    public string DatabaseName { get; set; }
}