namespace BookStore.Data.Abstraction;

public interface IDatabaseConfiguration
{
    string ConnectionString { get; set; }
    
    string DatabaseName { get; set; }
}